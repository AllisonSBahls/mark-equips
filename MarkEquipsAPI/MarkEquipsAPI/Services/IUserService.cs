using MarkEquipsAPI.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services
{
    public interface IUserService
    {
        public Task<UserDto> FindByIdAsync(int id);
        public Task<UserDto> UpdateAsync(int id);
        public Task<UserDto> CreateAsync(UserDto user);
        public Task<UserDto> LoginAsync { get; set; }
        public Task<UserDto> FindWithPagedSearch(string nameCollaborator, int size, int offset);
    }
}
