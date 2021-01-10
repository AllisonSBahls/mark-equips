using MarkEquipsAPI.Models;
using MarkEquipsAPI.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkEquipsAPI.Services.Implementations
{
    public class EquipmentServiceImplementation : IEntitieService
    {
        private readonly MarkEquipsContext _context;
        public EquipmentServiceImplementation(MarkEquipsContext context)
        {
            _context = context;
        }
        public Equipment Create(Equipment equipment)
        {
            return equipment;
        }
        public Equipment Update(Equipment equipment)
        {
            throw new NotImplementedException();
        }


        public List<Equipment> FindAll()
        {
        }

        public Equipment FindByID(long id)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
