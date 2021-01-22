using MarkEquipsAPI.Models;
using MarkEquipsAPI.Repository.Context;
using Microsoft.EntityFrameworkCore;
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

        public Task DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByIdAsync(int id)
        {
            var result = await _context.Users
                                .Include(ur => ur.UserRoles)
                                .ThenInclude(r => r.Role).SingleOrDefaultAsync(x => x.Id.Equals(id));
            return result;
        }

        public async Task<List<User>> FindWithPagedSearch(string name, int size, int offset)
        {
            IQueryable<User> result = _context.Users.Include(x=>x.UserRoles).ThenInclude(u => u.Role);

            if (!string.IsNullOrWhiteSpace(name))
            {
                result = result.Where(x => x.FullName.Contains(name));
            }
            result = result.OrderBy(d => d.FullName).Skip(offset).Take(size);

            return await result.ToListAsync();
        }

        public int GetCount(string FullNameUser)
        {
            var result = _context.Reservations.Where(x => x.User.FullName.Contains(FullNameUser)).Count();

            return result;
        }

        public async Task UpdateAsync(User item, User entity)
        {
            try
            {
                _context.Entry(item).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error in: " + e.Message);
            }
        }
    }
}
