using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Hypermedia.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services
{
    public interface IReserverService
    {
        Task<List<ReserverDto>> FindAllAsync();
        Task<PagedSearchDTO<ReserverDto>> FindWithPageSearch(string nameCollaborator, string nameEquipment, string sortDirection, int pageSize, int page);
        Task RevokeAsync(int id);
        Task AddReserverAsync(ReserverDto reserver);
        Task<ReserverDto> FindByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
