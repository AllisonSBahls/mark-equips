using MarkEquipsAPI.Data.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services
{
    public interface IReserverService
    {
        Task<List<ReserverDto>> FindAllAsync();
        Task RevokeAsync(int id);
        Task AddReserverAsync(ReserverDto reserver);
        Task<ReserverDto> FindByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<int> CountEquipmentReserver(int id);
    }
}
