using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services
{
    public interface IReserverService
    {
        Task<List<ReserverSchedule>> FindAllAsync();
        Task RevokeAsync(int id);
        Task AddReserverAsync(Reserver reserver);
        Task<ReserverDto> FindByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
