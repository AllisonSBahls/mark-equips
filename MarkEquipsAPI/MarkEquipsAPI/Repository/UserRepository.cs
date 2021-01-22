using MarkEquipsAPI.Models;
using MarkEquipsAPI.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MarkEquipsContext _context;

        public UserRepository(MarkEquipsContext context)
        {
            _context = context;
        }

        public Task<User> CreateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindWithPagedSearch(string nameCollaborator, int size, int offset)
        {
            throw new NotImplementedException();
        }
    }
}
