using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services
{
    public interface ICollaboratorService
    {
        Task<CollaboratorDto> CreateAsync(CollaboratorDto collaborator);
        Task<CollaboratorDto> FindByIDAsync(int id);
        Task<List<CollaboratorDto>> FindAllAsync();
        Task UpdateAsync(CollaboratorDto collaborator);
        Task DeleteAsync(int id);

    }
}
