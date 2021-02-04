using AutoMapper;
using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Helpers;
using MarkEquipsAPI.Hypermedia.Utils;
using MarkEquipsAPI.Models;
using MarkEquipsAPI.Models.Enums;
using MarkEquipsAPI.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MarkEquipsAPI.Services.Implementations
{
    public class ReserverServiceImplementation : IReserverService
    {
        private readonly IReserverRepository _repository;
        private readonly IMapper _mapper;
        private readonly AuthenticatedUser _user;


        public ReserverServiceImplementation(IReserverRepository repository, IMapper mapper, AuthenticatedUser user)
        {
            _repository = repository;
            _mapper = mapper;
            _user = user;
        }

        public async Task<List<ReserverDto>> FindAllAsync()
        {
            var result = await _repository.FindAllAsync();
            return _mapper.Map<List<ReserverDto>>(result);
        }

        public async Task<PagedSearchDTO<ReserverDto>> FindWithPageSearch(string nameCollaborator, string nameEquipment, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection) && !sortDirection.Equals("desc")) ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;
            var reservations = await _repository.FindWithPagedSearch(nameCollaborator, nameEquipment, size, offset);
            var totalResult = _repository.GetCount(nameCollaborator, nameEquipment);

            var searchPage = new PagedSearchDTO<ReserverDto>
            {
                CurrentPage = page,
                List = _mapper.Map<List<ReserverDto>>(reservations),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResult
            };
            return searchPage;
        }

        public async Task<ReserverDto> FindByIdAsync(int id)
        {
            var reservationsDto = await _repository.FindByIdAsync(id);
            return _mapper.Map<ReserverDto>(reservationsDto); 
        }

        public async Task AddReserverAsync(ReserverDto reserver)
        {
            var result = _mapper.Map<Reserver>(reserver);
            bool isValidate = await _repository.IsValidationAsync(result.EquipmentId, result.ScheduleId, result.Date, ReserveStatus.RESERVED);
            if (isValidate)
            {
                throw new Exception("Equipment already registered with that same time and date, please choose another time or equipment \n");
            }
            result.Status = ReserveStatus.RESERVED;
            await _repository.CreateAsync(result);
        }

        public async Task RevokeAsync(int id)
        {
            try
            {
                var statusUpdate = new Reserver() { Id = id, Status = ReserveStatus.CANCELED };
                await _repository.RevokeAsync(statusUpdate);
            }
            catch (Exception e)
            {
                throw new Exception("Error in Update Reservations" + e.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var result = await _repository.FindByIdAsync(id);
                if (result != null)
                {
                    await _repository.DeleteAsync(result);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        public async Task<PagedSearchDTO<ReserverDto>> FindWithPageSearchForUser(string equipment, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection) && !sortDirection.Equals("desc")) ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;
            int userId = int.Parse(_user.Id);

            var reservations = await _repository.FindWithPagedSearchForUser(userId, equipment, size, offset );
            var totalResult = _repository.GetCountResUser(userId, equipment);

            var searchPage = new PagedSearchDTO<ReserverDto>
            {
                CurrentPage = page,
                List = _mapper.Map<List<ReserverDto>>(reservations),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResult
            };
            return searchPage;
        }
    }
}


