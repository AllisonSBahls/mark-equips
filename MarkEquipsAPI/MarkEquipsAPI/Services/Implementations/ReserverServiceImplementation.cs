using AutoMapper;
using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Models;
using MarkEquipsAPI.Models.Enums;
using MarkEquipsAPI.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MarkEquipsAPI.Services.Implementations
{
    public class ReserverServiceImplementation : IReserverService
    {
        private readonly ReserverRepository _repository;
        private readonly IMapper _mapper;

        public ReserverServiceImplementation(ReserverRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ReserverSchedule>> FindAllAsync()
        {
            return await _repository.FindAllAsync(); ;
        }

        public async Task<ReserverDto> FindByIdAsync(int id)
        {
            var reservationsDto = await _repository.FindByIdAsync(id);
            return _mapper.Map<ReserverDto>(reservationsDto); 
        }

        public async Task AddReserverAsync(Reserver reserver)
        {
            bool isValidate = await _repository.IsValidationAsync(reserver.EquipmentId, reserver.ReserverSchedules[0].ScheduleId, reserver.Date, ReserveStatus.RESERVED);

            if (isValidate)
            {
                throw new Exception("Equipment already registered with that same time and date, please choose another time or equipment \n");
            }
            await _repository.AddReserverAsync(reserver);
        }

        public async Task RevokeAsync(int id)
        {
            try
            {
                var statusUpdate = new ReserverSchedule() { ReserverId = id, Status = ReserveStatus.CANCELED };
                await _repository.RevokeReserverAsync(statusUpdate);
            }
            catch (Exception e)
            {
                throw new Exception("Error in Update Reserver" + e.Message);
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


    }
}


