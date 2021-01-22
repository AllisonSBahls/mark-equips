using MarkEquipsAPI.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services
{
    public interface IUserService
    {
        Task<UserDto> FindByIdAsync(int id);
        Task<UserDto> UpdateAsync(int id);
        Task<UserDto> CreateAsync(UserDto user);
        Task<LoginDto> LoginAsync(LoginDto user);
        Task<UserDto> FindWithPagedSearch(string nameCollaborator, int size, int offset);
    }
}
