using AutoMapper;
using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Hypermedia.Utils;
using MarkEquipsAPI.Models;
using MarkEquipsAPI.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services.Implementations
{
    public class EquipmentServiceImplementation : IEquipmentService
    {
        private readonly IRepository<Equipment> _repository;
        private readonly IMapper _mapper;


        public EquipmentServiceImplementation(IRepository<Equipment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedSearchDTO<EquipmentDto>> FindWithPageSearch(string name, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection) && !sortDirection.Equals("desc")) ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from equipments e  where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(name)) query += $"and e.name like '%{name}%'";
            query += $"order by e.name {sort} limit {size} offset {offset}";

            string countQuery = @"select count(*) from equipments e  where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(name)) countQuery += $"and e.name like '%{name}%'";
          
           var equipments = await _repository.FindWithPagedSearch(query);
            int totalResult = _repository.GetCount(countQuery);
            var result = _mapper.Map<List<EquipmentDto>>(equipments);

            var searchPage = new PagedSearchDTO<EquipmentDto>
            {
                CurrentPage = page,
                List = result,
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResult
            };

            return searchPage;
        }
        public async Task<EquipmentDto> FindByIDAsync(int id)
        {
            var equipment = await _repository.FindByIDAsync(id);
            return _mapper.Map<EquipmentDto>(equipment);
        }

        public async Task<EquipmentDto> CreateAsync(EquipmentDto equipment)
        {
            var result = _mapper.Map<Equipment>(equipment);
            result = await _repository.CreateAsync(result);
            return _mapper.Map<EquipmentDto>(result);
        }

        public async Task UpdateAsync(EquipmentDto equipment)
        {
            var result = _mapper.Map<Equipment>(equipment);
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
