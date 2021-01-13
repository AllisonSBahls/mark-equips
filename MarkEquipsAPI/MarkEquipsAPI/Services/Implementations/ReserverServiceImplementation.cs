using MarkEquipsAPI.Models;
using MarkEquipsAPI.Models.Enums;

using MarkEquipsAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MarkEquipsAPI.Services.Implementations
{
    public class ReserverServiceImplementation : IReserverService
    {
        private readonly ReserverRepository _repository;

        public ReserverServiceImplementation(ReserverRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Reserver>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<Reserver> FindByIdAsync(int id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public async Task AddReserverAsync(Reserver reserver)
        {
            bool isValidate = await _repository.IsValidationAsync(reserver.EquipmentId, reserver.Schedules[0].ScheduleId, reserver.Date, ReserveStatus.RESERVED);
            Console.WriteLine(isValidate);
            if (isValidate)
            {
                throw new Exception("Equipment already  registered with that same time and date, please choose another time or equipment \n");
            }
            await _repository.AddReserverAsync(reserver);
        }

        public async Task RevokeAsync(int id)
        {
            try {
            var statusUpdate = new Reserver() { Id = id, Status = ReserveStatus.CANCELED };
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
                if (result != null) { 
                    await _repository.DeleteAsync(id, result);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

 
    }
}


