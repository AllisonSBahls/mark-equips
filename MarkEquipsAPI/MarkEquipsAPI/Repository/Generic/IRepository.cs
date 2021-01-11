using MarkEquipsAPI.Models.Base;
using System.Collections.Generic;

namespace MarkEquipsAPI.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T entity);
        T FindByID(int id);
        List<T> FindAll();
        T Update(T entity);
        void Delete(int id);
        bool Exists(int id);
    }
}
