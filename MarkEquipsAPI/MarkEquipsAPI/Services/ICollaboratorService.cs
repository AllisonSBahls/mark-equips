using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Hypermedia.Utils;
using MarkEquipsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services
{
    public interface ICollaboratorService
    {
        Task<CollaboratorDto> CreateAsync(CollaboratorDto collaborator);
        Task<CollaboratorDto> FindByIDAsync(int id);
        Task<PagedSearchDTO<CollaboratorDto>> FindWithPageSearch(string name, string sortDirection, int pageSize, int page);
        Task UpdateAsync(CollaboratorDto collaborator);
        Task DeleteAsync(int id);

    }
}
