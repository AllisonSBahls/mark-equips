using System.Collections.Generic;
using System.Threading.Tasks;
using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Hypermedia.Utils;

namespace MarkEquipsAPI.Services
{
    public interface IEquipmentService
    {
        Task<EquipmentDto> CreateAsync(EquipmentDto equipment);
        Task<List<EquipmentDto>> FindAllAsync();
        Task<EquipmentDto> FindByIDAsync(int id);
        Task<PagedSearchDTO<EquipmentDto>> FindWithPageSearch(string name, string sortDirection, int pageSize, int page);
        Task UpdateAsync(EquipmentDto equipment);
        Task DeleteAsync(int id);
    }
}
