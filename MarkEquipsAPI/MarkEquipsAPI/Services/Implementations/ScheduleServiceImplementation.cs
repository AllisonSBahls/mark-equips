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

        public Schedule Create(Schedule schedule)
        {
            return _repository.Create(schedule);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Schedule> FindAll()
        {
            return _repository.FindAll();
        }

        public Schedule FindByID(int id)
        {
            return _repository.FindByID(id);
        }

        public Schedule Update(Schedule schedule)
        {
            return _repository.Update(schedule);
        }
    }
}
