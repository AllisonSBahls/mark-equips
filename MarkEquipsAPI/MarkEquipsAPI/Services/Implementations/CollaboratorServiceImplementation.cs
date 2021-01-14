using MarkEquipsAPI.Models;
using MarkEquipsAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services.Implementations
{
    public class CollaboratorServiceImplementation : ICollaboratorService
    {
        private readonly IRepository<Collaborator> _repository;

        public CollaboratorServiceImplementation(IRepository<Collaborator> repository)
        {
            _repository = repository;
        }

        public async Task<List<Collaborator>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<Collaborator> FindByIDAsync(int id)
        {
            return await _repository.FindByIDAsync(id);
        }

        public async Task<Collaborator> CreateAsync(Collaborator collaborator)
        {
            return await _repository.CreateAsync(collaborator);
        }

        public async Task UpdateAsync(Collaborator collaborator)
        {
            var result = await _repository.FindByIDAsync(collaborator.Id);
            if (result != null)
            {
                await _repository.UpdateAsync(result, collaborator);
            }
        }
        public async Task DeleteAsync(int id)
        {
            var result = await _repository.FindByIDAsync(id);
            if (result != null)
            {
                await _repository.DeleteAsync(result);
            }
        }

    }
}
