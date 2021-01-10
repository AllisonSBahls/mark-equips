using MarkEquipsAPI.Models;
using MarkEquipsAPI.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkEquipsAPI.Repository.Implementations
{
    public class EquipmentRepositoryImplementation : IEntitieRepository
    {
        private readonly MarkEquipsContext _context;

        public EquipmentRepositoryImplementation(MarkEquipsContext context)
        {
            _context = context;
        }

        public List<Equipment> FindAll()
        {
            return _context.Equipments.ToList();
        }

        public Equipment FindByID(long id)
        {
            return _context.Equipments.SingleOrDefault(e => e.Id.Equals(id));
        }

        public Equipment Create(Equipment equipment)
        {
            try
            {
                _context.Add(equipment);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return equipment;
        }

        public Equipment Update(Equipment equipment)
        {
            if (!Exists(equipment.Id)) return new Equipment();

            var result = _context.Equipments.SingleOrDefault(e => e.Id.Equals(equipment.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(equipment);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return equipment;
        }

        public void Delete(long id)
        {
            var result = _context.Equipments.SingleOrDefault(e => e.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Equipments.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public bool Exists(long id)
        {
            return _context.Equipments.Any(e => e.Id.Equals(id));
        }
    }
}
