using AutoMapper;
using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Hypermedia.Utils;
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

        public async Task<PagedSearchDTO<CollaboratorDto>> FindWithPageSearch(string name, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection) && !sortDirection.Equals("desc")) ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            /*Essa query tambem pode ser escrita usando Linq porém foi optado pelo SQL para entender as outras formas que é possivel trabalhar 
             * dentro da linguagem
             */
            string query = @"select * from collaborators c where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(name)) query += $"and c.name like '%{name}%'";
            query += $"order by c.name {sort} limit {size} offset {offset}";

            string countQuery = @"select count(*) from collaborators c  where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(name)) countQuery += $"and c.name like '%{name}%'";

            var collaborators = await _repository.FindWithPagedSearch(query);
            int totalResult = _repository.GetCount(countQuery);
            var result = _mapper.Map<List<CollaboratorDto>>(collaborators);

            var searchPage = new PagedSearchDTO<CollaboratorDto>
            {
                CurrentPage = page,
                List = result,
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResult
            };

            return searchPage;
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
