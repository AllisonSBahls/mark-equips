using MarkEquipsAPI.Models;
using System.Collections.Generic;

namespace MarkEquipsAPI.Services.Implementations
{
    public interface IEntitieServices
    {
        Equipment Create(Equipment equip);
        Equipment Update(Equipment equip);
        Equipment FindById(long id);
        List<Equipment> FindAll();
        void Delete(long id);

    }
}
