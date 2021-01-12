using MarkEquipsAPI.Models;
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
            var reservations =  _context.Reservations
                .Include(rs => rs.Schedules)
                   .ThenInclude(s => s.Schedule);

            return await reservations.AsNoTracking().ToListAsync();
            
        }

        
        public async Task<Reserver> AddReserverAsync(Reserver reserver)
        {
            try
            {
                _context.Reservations.Add(reserver);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error in Insert Reserver" + e.Message);
            }

            return reserver;
        }

        /*
        Validate if the equipment has the available time or not
         */
        public bool IsValidation(int equipId, int schedId, DateTime date)
        {
            var validate = _context.ReserverSchedules
                .Where(s => s.ScheduleId.Equals(schedId))
                .Include(r => r.Reserver)
                .Where(r => r.Reserver.EquipmentId.Equals(equipId) && r.Reserver.Date.Equals(date));

            return validate.Any() ? true : false;
        }
    }
}
