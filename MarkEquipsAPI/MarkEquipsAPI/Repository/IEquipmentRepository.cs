using MarkEquipsAPI.Models;
using MarkEquipsAPI.Models;
using System.Collections.Generic;

namespace MarkEquipsAPI.Repository
{
    public interface IEquipmentRepository : IRepository<Equipment>
    {
        int GetCountEquipReserves(int id);
    }
}
