using MarkEquipsAPI.Models;
using System.Collections.Generic;

namespace MarkEquipsAPI.Repository
{
    public interface IEntitieRepository
    {
        Equipment Create(Equipment equipment);
        Equipment FindByID(long id);
        List<Equipment> FindAll();
        Equipment Update(Equipment equipment);
        void Delete(long id);
        bool Exists(long id);
    }
}
