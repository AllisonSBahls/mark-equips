using MarkEquipsAPI.Models;
using System.Collections.Generic;

namespace MarkEquipsAPI.Services
{
    public interface IScheduleService
    {
        Schedule Create(Schedule schedule);
        Schedule FindByID(int id);
        List<Schedule> FindAll();
        Schedule Update(Schedule schedule);
        void Delete(int id);

    }
}
