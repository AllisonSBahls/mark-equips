using AutoMapper;
using MarkEquipsAPI.Data.DTOs;
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
        private readonly IMapper _mapper;

        public CollaboratorServiceImplementation(IRepository<Collaborator> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CollaboratorDto>> FindAllAsync()
        {
            var collaborator = await _repository.FindAllAsync();
            return _mapper.Map<List<CollaboratorDto>>(collaborator);
        }

        public async Task<CollaboratorDto> FindByIDAsync(int id)
        {
            var collaborator = await _repository.FindByIDAsync(id);
            return _mapper.Map<CollaboratorDto>(collaborator);
        }

        public async Task<CollaboratorDto> CreateAsync(CollaboratorDto collaborator)
        {
            var result = _mapper.Map<Collaborator>(collaborator);
            result = await _repository.CreateAsync(result);
            return _mapper.Map<CollaboratorDto>(result);
        }

        public async Task UpdateAsync(CollaboratorDto collaborator)
        {
            var result = _mapper.Map<Collaborator>(collaborator);
            var find = await _repository.FindByIDAsync(result.Id);
            if (result != null)
            {
                await _repository.UpdateAsync(find, result);
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
