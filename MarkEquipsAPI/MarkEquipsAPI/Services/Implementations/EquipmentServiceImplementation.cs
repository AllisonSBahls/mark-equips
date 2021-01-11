using MarkEquipsAPI.Models;
using MarkEquipsAPI.Repository;
using System.Collections.Generic;

namespace MarkEquipsAPI.Services.Implementations
{
    public class EquipmentServiceImplementation : IEntitieService
    {
        private readonly IRepository<Equipment> _repository;

        public EquipmentServiceImplementation(IRepository<Equipment> repository)
        {
            _repository = repository;
        }

        public List<Equipment> FindAll()
        {
            return _repository.FindAll();
        }

        public Equipment FindByID(int id)
        {
            return _repository.FindByID(id);
        }

        public Equipment Create(Equipment equipment)
        {
            
            return _repository.Create(equipment);
        }

        public Equipment Update(Equipment equipment)
        {
            return _repository.Update(equipment);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
      
    }
}
