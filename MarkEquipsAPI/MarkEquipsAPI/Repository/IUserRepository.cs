using MarkEquipsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Repository
{
    public interface IUserRepository
    {
        public Task<User> FindByIdAsync(int id);
        public Task<User> UpdateAsync(int id);
        public Task<User> CreateAsync(User user);
        public Task<User> FindWithPagedSearch(string nameCollaborator, int size, int offset);
    }
}
