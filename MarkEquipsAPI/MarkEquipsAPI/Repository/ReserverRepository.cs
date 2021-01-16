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
    public class ReserverRepository
    {
        private readonly MarkEquipsContext _context;

        public ReserverRepository(MarkEquipsContext context)
        {
            _context = context;
        }
        public async Task<List<ReserverSchedule>> FindAllAsync()
        {
          
            var reservations = _context.ReserverSchedules
                .Include(rs => rs.Reserver)
                   .Include(s => s.Schedule);

            return await reservations.AsNoTracking().ToListAsync();
        }

        public async Task<Reserver> FindByIdAsync(int id)
        {
            var result = await _context.Reservations
                .Include(rs => rs.ReserverSchedules)
                   .ThenInclude(s => s.Schedule)
               
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
                throw new Exception("Error in Insert Reserver " + e.Message);
            }
        }

        public async Task RevokeReserverAsync(ReserverSchedule reserver)
        {
            try { 
            _context.ReserverSchedules.Attach(reserver);
            _context.Entry(reserver).Property(x => x.Status).IsModified = true;
            await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error in Update Reserver" + e.Message);
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
            var validate = _context.ReserverSchedules
                    .Where(s => s.ScheduleId.Equals(schedId)
                            && s.Status.Equals(status))
                .Include(r => r.Reserver)
                    .Where(r => r.Reserver.EquipmentId.Equals(equipId)
                        && r.Reserver.Date.Equals(date));
                        
            return await validate.AnyAsync();
        }
    }
}
