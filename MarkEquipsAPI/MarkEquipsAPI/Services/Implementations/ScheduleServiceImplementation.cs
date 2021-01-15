using AutoMapper;
using MarkEquipsAPI.Data.DTO;
using MarkEquipsAPI.Models;
using MarkEquipsAPI.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services.Implementations
{
    public class ScheduleServiceImplementation : IScheduleService
    {
        private readonly IRepository<Schedule> _repository;
        private readonly IMapper _mapper;

        public ScheduleServiceImplementation(IRepository<Schedule> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ScheduleDto>> FindAllAsync()
        {
            var schedule = await _repository.FindAllAsync();
            return _mapper.Map<List<ScheduleDto>>(schedule);
        }

        public async Task<ScheduleDto> FindByIDAsync(int id)
        {
            var schedule = await _repository.FindByIDAsync(id);
            return _mapper.Map<ScheduleDto>(schedule); 
        }

        public async Task<ScheduleDto> CreateAsync(ScheduleDto schedule)
        {
            var result = _mapper.Map<Schedule>(schedule);
            result = await _repository.CreateAsync(result);
            return _mapper.Map<ScheduleDto>(result);
        }

        public async Task UpdateAsync(ScheduleDto schedule)
        {
            var result = _mapper.Map<Schedule>(schedule);
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
