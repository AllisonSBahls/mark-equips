using MarkEquipsAPI.Data.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services
{
    public interface IEquipmentService
    {
        Task<EquipmentDto> CreateAsync(EquipmentDto equipment);
        Task<EquipmentDto> FindByIDAsync(int id);
        Task<List<EquipmentDto>> FindAllAsync();
        Task UpdateAsync(EquipmentDto equipment);
        Task DeleteAsync(int id);

    }
}
