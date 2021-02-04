using MarkEquipsAPI.Models;

namespace MarkEquipsAPI.Repository
{
    public interface IEquipmentRepository : IRepository<Equipment>
    {
        int GetCountEquipReserves(int id);
    }
}
