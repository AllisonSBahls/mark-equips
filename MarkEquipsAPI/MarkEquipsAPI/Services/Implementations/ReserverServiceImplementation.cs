using MarkEquipsAPI.Models;
using MarkEquipsAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services.Implementations
{
    public class ReserverServiceImplementation : IReserverService
    {
        private readonly IReserverRepository _repository;

        public ReserverServiceImplementation(IReserverRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Reserver>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<Reserver> AddReserverAsync(Reserver reserver)
        {
            bool isValidate = _repository.IsValidation(reserver.EquipmentId, reserver.Schedules[0].ScheduleId, reserver.Date);

            if (isValidate)
            {
                throw new Exception("Equipment already  registered with that same time and date, please choose another time or equipment");
            }
            return await _repository.AddReserverAsync(reserver);
        }
    }
}


