using MarkEquipsAPI.Models;
using System.Collections.Generic;

namespace MarkEquipsAPI.Services
{
    public interface IEntitieService
    {
        Equipment Create(Equipment equipment);
        Equipment FindByID(int id);
        List<Equipment> FindAll();
        Equipment Update(Equipment equipment);
        void Delete(int id);

    }
}
