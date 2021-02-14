using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Hypermedia.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services
{
    public interface IUserService
    {
        Task<UserDto> FindByIdAsync(int id);
        Task<UserDto> UpdateAsync(UserDto user);
        Task<UserDto> CreateAsync(UserDto user);
        Task<LoginDto> LoginAsync(LoginDto user);
        Task DeleteAsync(int id);
        Task<PagedSearchDTO<UserDto>> FindWithPageSearch(string fullname, string sortDirection, int pageSize, int page);
        bool ValidateToken(string authToken);
    }
}
