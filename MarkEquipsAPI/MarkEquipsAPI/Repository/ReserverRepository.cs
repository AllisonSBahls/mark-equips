using MarkEquipsAPI.Models;
using MarkEquipsAPI.Models.Enums;
using MarkEquipsAPI.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Repository
{
    public class ReserverRepository : IReserverRepository
    {
        private readonly MarkEquipsContext _context;

        public ReserverRepository(MarkEquipsContext context)
        {
            _context = context;
        }
        public async Task<List<Reserver>> FindAllAsync()
        {
            var result = await _context.Reservations
                .Include(c => c.Collaborator)
                .Include(e => e.Equipment)
                .Include(s => s.Schedule).AsNoTracking().OrderBy(x=>x.Id).ToListAsync();

            return result;
        }

        public async Task<Reserver> FindByIdAsync(int id)
        {
            var result = await _context.Reservations
                .Include(c => c.Collaborator)
                .Include(e => e.Equipment)
                .Include(s => s.Schedule).AsNoTracking()
                   .SingleOrDefaultAsync(p => p.Id.Equals(id));
            return result;
        }

        public async Task AddReserverAsync(Reserver reserver)
        {
            try
            {
                _context.Reservations.Add(reserver);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw new Exception("Error in Insert Reservations " + e.Message);
            }
        }

        public async Task RevokeReserverAsync(Reserver reserver)
        {
            try { 
            _context.Reservations.Attach(reserver);
            _context.Entry(reserver).Property(x => x.Status).IsModified = true;
            await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error in Update Reservations" + e.Message);
            }
        }

        public async Task DeleteAsync(Reserver reserver)
        {
            _context.Reservations.Remove(reserver);
            await _context.SaveChangesAsync();
        }

        /*
        Validate if the equipment has the available time or not
         */
        public async Task<bool> IsValidationAsync(int equipId, int schedId, DateTime date, ReserveStatus status)
        {
            var validate = _context.Reservations
                    .Where(s => s.ScheduleId.Equals(schedId)
                            && s.Status.Equals(status)
                            && s.EquipmentId.Equals(equipId)
                            && s.Date.Equals(date));
                        
            return await validate.AnyAsync();
        }

        public async Task<int> CountEquipmentReserverAsync(int equipId)
        {
            var count = await _context.Reservations.CountAsync(c => c.EquipmentId.Equals(equipId));
            return count;
        }

        public async Task<List<Reserver>> FindWithPagedSearch(string nameCollaborator, string nameEquipment, int size, int offset )
        {
            IQueryable<Reserver> result = _context.Reservations
                .Include(c => c.Collaborator)
                .Include(e => e.Equipment)
                .Include(s => s.Schedule);

            if (!string.IsNullOrWhiteSpace(nameCollaborator) && !string.IsNullOrWhiteSpace(nameEquipment))
            {
                result = result.Where(x => x.Collaborator.Name.Contains(nameCollaborator) && x.Equipment.Name.Contains(nameEquipment));
            }
            else if (!string.IsNullOrWhiteSpace(nameCollaborator) && string.IsNullOrWhiteSpace(nameEquipment))
            {
                result = result.Where(x => x.Collaborator.Name.Contains(nameCollaborator));
            }
            else if (string.IsNullOrWhiteSpace(nameCollaborator) && !string.IsNullOrWhiteSpace(nameEquipment))
            {
                result = result.Where(x => x.Equipment.Name.Contains(nameEquipment));
            }
            result = result.OrderBy(d => d.Date).Skip(offset).Take(size);

            return await result.ToListAsync();
        }

        public int GetCount(string nameCollaborator, string nameEquipment)
        {
           var result = _context.Reservations.Where(x => x.Collaborator.Name.Contains(nameCollaborator) ||
           x.Equipment.Name.Contains(nameEquipment)).Count();

            return result;
        }
    }
}
