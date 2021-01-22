using AutoMapper;
using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services.Implementations
{
    public class UserServiceImplementation : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public UserServiceImplementation(IConfiguration configuration, UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public Task<UserDto> LoginAsync { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task<UserDto> CreateAsync(UserDto userDto)
        {
                var user = _mapper.Map<User>(userDto);
                var result = await _userManager.CreateAsync(user, userDto.Password);
                await _userManager.AddToRoleAsync(user, "Manager");
                var userToReturn = _mapper.Map<UserDto>(user);
                if (result.Succeeded)
                {
                    return userToReturn;
                }
            return null;
        }

        public Task<UserDto> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> FindWithPagedSearch(string nameCollaborator, int size, int offset)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
