using MarkEquipsAPI.Models;
using System;
using System.Collections.Generic;

namespace MarkEquipsAPI.Services.Implementations
{
    public class EquipmentServiceImplementation : IEntitieService
    {
        public Equipment Create(Equipment equipment)
        {
            return equipment;
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Equipment> FindAll()
        {
            throw new NotImplementedException();
        }

        public Equipment FindByID(long id)
        {
            throw new NotImplementedException();
        }

        public Equipment Update(Equipment equipment)
        {
            throw new NotImplementedException();
        }
    }
}
