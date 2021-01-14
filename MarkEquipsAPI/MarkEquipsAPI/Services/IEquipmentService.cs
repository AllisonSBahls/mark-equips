using MarkEquipsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services
{
    public interface IEquipmentService
    {
        Task<Equipment> CreateAsync(Equipment equipment);
        Task<Equipment> FindByIDAsync(int id);
        Task<List<Equipment>> FindAllAsync();
        Task UpdateAsync(Equipment equipment);
        Task DeleteAsync(int id);

    }
}
