using MarkEquipsAPI.Models;
using MarkEquipsAPI.Models.Context;
using MarkEquipsAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkEquipsAPI.Services.Implementations
{
    public class EquipmentServiceImplementation : IEntitieService
    {
        private readonly IEntitieRepository _repository;

        public EquipmentServiceImplementation(IEntitieRepository repository)
        {
            _repository = repository;
        }

        public List<Equipment> FindAll()
        {
            return _repository.FindAll();
        }

        public Equipment FindByID(long id)
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

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
      
    }
}
