using MarkEquipsAPI.Models;
using MarkEquipsAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services.Implementations
{
    public class ScheduleServiceImplementation : IScheduleService
    {
        private readonly IRepository<Schedule> _repository;


        public ScheduleServiceImplementation(IRepository<Schedule> repository)
        {
            _repository = repository;
        }

        public async Task<List<Schedule>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<Schedule> FindByIDAsync(int id)
        {
            return await _repository.FindByIDAsync(id);
        }

        public async Task<Schedule> CreateAsync(Schedule schedule)
        {
            return await _repository.CreateAsync(schedule);
        }

        public async Task UpdateAsync(Schedule schedule)
        {
            var result = await _repository.FindByIDAsync(schedule.Id);
            if (result != null)
            {
                await _repository.UpdateAsync(result, schedule);
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
