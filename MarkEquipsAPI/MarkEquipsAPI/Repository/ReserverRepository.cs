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
        public async Task<List<Reserver>> FindAllAsync()
        {
          
            var reservations = _context.Reservations
                .Include(rs => rs.Schedules)
                   .ThenInclude(s => s.Schedule);

            return await reservations.AsNoTracking().ToListAsync();
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

        public async Task RevokeReserverAsync(Reserver reserver)
        {
            try { 
            _context.Reservations.Attach(reserver);
            _context.Entry(reserver).Property(x => x.Status).IsModified = true;
            await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error in Update Reserver" + e.Message);
            }
        }

        public async Task<Reserver> FindByIdAsync(int id)
        {
            var result = await _context.Reservations.SingleOrDefaultAsync(p => p.Id.Equals(id));
            return result;
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
                    .Where(s => s.ScheduleId.Equals(schedId))
                .Include(r => r.Reserver)
                    .Where(r => r.Reserver.EquipmentId.Equals(equipId)
                        && r.Reserver.Date.Equals(date)
                        && r.Reserver.Status.Equals(status));
                        

            return await validate.AnyAsync() ? true : false;
        }
    }
}
