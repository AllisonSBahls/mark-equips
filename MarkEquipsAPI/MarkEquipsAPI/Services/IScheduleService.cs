using MarkEquipsAPI.Data.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services
{
    public interface IScheduleService
    {
        Task<ScheduleDto> CreateAsync(ScheduleDto schedule);
        Task<ScheduleDto> FindByIDAsync(int id);
        Task<List<ScheduleDto>> FindAllAsync();
        Task UpdateAsync(ScheduleDto schedule);
        Task DeleteAsync(int id);

    }
}
