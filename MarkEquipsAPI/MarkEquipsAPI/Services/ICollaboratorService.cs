using MarkEquipsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services
{
    public interface ICollaboratorService
    {
        Task<Collaborator> CreateAsync(Collaborator collaborator);
        Task<Collaborator> FindByIDAsync(int id);
        Task<List<Collaborator>> FindAllAsync();
        Task UpdateAsync(Collaborator collaborator);
        Task DeleteAsync(int id);

    }
}
