using MarkEquipsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services
{
    public interface IScheduleService
    {
        Task<Schedule> CreateAsync(Schedule schedule);
        Task<Schedule> FindByIDAsync(int id);
        Task<List<Schedule>> FindAllAsync();
        Task UpdateAsync(Schedule schedule);
        Task DeleteAsync(int id);

    }
}
