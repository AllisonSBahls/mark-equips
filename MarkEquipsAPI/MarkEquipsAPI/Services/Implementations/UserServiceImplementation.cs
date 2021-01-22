using AutoMapper;
using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        private readonly IMapper _mapper;

        public UserServiceImplementation(IConfiguration configuration, UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, RoleManager<Role> roleManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _roleManager = roleManager;
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
            var ConverterId = id.ToString();
            var user = await _userManager.FindByIdAsync(ConverterId);
            return _mapper.Map<UserDto>(user);
        }

        public Task<UserDto> FindWithPagedSearch(string nameCollaborator, int size, int offset)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginDto> LoginAsync(LoginDto userDto)
        {
            var user = await _userManager.FindByNameAsync(userDto.UserName);
            var result = await _signInManager.CheckPasswordSignInAsync(user, userDto.Password, false);
            var appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == userDto.UserName.ToUpper());

            var userToReturn = _mapper.Map<LoginDto>(appUser);

            return new LoginDto
            {
                Token = GenerateJWToken(appUser).Result,
                UserName = userToReturn.UserName,
                Password = ""
            };
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
    }
}
