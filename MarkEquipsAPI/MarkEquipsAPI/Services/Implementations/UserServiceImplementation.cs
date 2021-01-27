using AutoMapper;
using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Hypermedia.Utils;
using MarkEquipsAPI.Models;
using MarkEquipsAPI.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services.Implementations
{
    public class UserServiceImplementation : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserServiceImplementation(IConfiguration configuration, UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, RoleManager<Role> roleManager, IUserRepository repository)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _repository = repository;
        }

        public async Task<UserDto> CreateAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var applicationRole = await _roleManager.FindByNameAsync(userDto.Role);
            if (applicationRole != null)
            {
                var result = await _userManager.CreateAsync(user, userDto.Password);
                await _userManager.AddToRoleAsync(user, applicationRole.Name);
                var userToReturn = _mapper.Map<UserDto>(user);
                userToReturn.Role = userDto.Role;
                if (result.Succeeded)
                {
                    return userToReturn;
                }
            }
            return null;
        }

        public async Task<UserDto> FindByIdAsync(int id)
        {
            var result = await _repository.FindByIdAsync(id);
            var userDto = _mapper.Map<UserDto>(result);
            userDto.Role = result.UserRoles[0].Role.Name;
            return userDto;
        }

        public async Task<PagedSearchDTO<UserDto>> FindWithPageSearch(string fullname, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection) && !sortDirection.Equals("desc")) ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;
            var user = await _repository.FindWithPagedSearch(fullname, size, offset);
            var totalResult = _repository.GetCount(fullname);
            var userDto = _mapper.Map<List<UserDto>>(user);

            var searchPage = new PagedSearchDTO<UserDto>
            {
                CurrentPage = page,
                List = userDto,
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResult
            };
            return searchPage;
        }

        public async Task<LoginDto> LoginAsync(LoginDto userDto)
        {
            var user = await _userManager.FindByNameAsync(userDto.UserName);
            var result = await _signInManager.CheckPasswordSignInAsync(user, userDto.Password, false);
            var appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == userDto.UserName.ToUpper());
            var userToReturn = _mapper.Map<LoginDto>(appUser);
            if (result.Succeeded)
            {
                return new LoginDto
                {
                    Token = GenerateJWToken(appUser).Result,
                    UserName = userToReturn.UserName,
                };
            }
            return null;
        }

        private async Task<string> GenerateJWToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserName.ToString()),
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.ASCII
                             .GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<UserDto> UpdateAsync(UserDto userDto)
        {
            var result = _mapper.Map<User>(userDto);
            var find = await _repository.FindByIdAsync(result.Id);
            if (result != null)
            {
                await _repository.UpdateAsync(find, result);
            }
            var user = _mapper.Map<UserDto>(result);
            return user;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(result);
        }
    }
}
