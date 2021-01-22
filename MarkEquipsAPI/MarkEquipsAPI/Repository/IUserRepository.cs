using MarkEquipsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Repository
{
    public interface IUserRepository
    {
        Task<User> FindByIdAsync(int id);
        Task<List<User>> FindWithPagedSearch(string name, int size, int offset);
        Task UpdateAsync(User item, User entity);

        public int GetCount(string FullNameUser);
        Task DeleteAsync(User entity);



    }
}
