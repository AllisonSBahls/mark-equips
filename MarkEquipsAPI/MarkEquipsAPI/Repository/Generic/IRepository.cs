using MarkEquipsAPI.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> CreateAsync(T entity);
        Task<T> FindByIDAsync(int id);
        Task<List<T>> FindAllAsync();
        Task UpdateAsync(T item, T entity);
        Task DeleteAsync(T entity);
        Task<bool> ExistsAsync(int id);
        Task<List<T>> FindWithPagedSearch(string query);
        int GetCount(string query);

    }
}
