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
                .Include(c => c.User)
                .Include(e => e.Equipment)
                .Include(s => s.Schedule).AsNoTracking().OrderBy(x => x.Id).ToListAsync();

            return result;
        }

        public async Task<Reserver> FindByIdAsync(int id)
        {
            var result = await _context.Reservations
                .Include(c => c.User)
                .Include(e => e.Equipment)
                .Include(s => s.Schedule).AsNoTracking()
                   .SingleOrDefaultAsync(p => p.Id.Equals(id));
            return result;
        }

        public async Task CreateAsync(Reserver reserver)
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

        public async Task StatusReserverAsync(Reserver reserver)
        {
            try
            {
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

        public async Task<List<Reserver>> FindWithPagedSearch(
            string FullNameUser,
            string FullNameEquipment,
            int size, int offset,
            DateTime? date,
            int status)
        {
            IQueryable<Reserver> result = _context.Reservations
                .Include(c => c.User)
                .Include(e => e.Equipment)
                .Include(s => s.Schedule);

            ReserveStatus reserveStatus = (ReserveStatus)status;

            if (!string.IsNullOrWhiteSpace(FullNameUser) &&
                !string.IsNullOrWhiteSpace(FullNameEquipment) &&
                date.HasValue &&
                status != 0)
            {
                result = result.Where(x => x.User.FullName.Contains(FullNameUser) && x.Equipment.Name.Contains(FullNameEquipment) && x.Date.Equals(date) && x.Status.Equals(reserveStatus));
            }


            else if (!string.IsNullOrWhiteSpace(FullNameUser) &&
                  string.IsNullOrWhiteSpace(FullNameEquipment) &&
                  date.HasValue &&
                  status != 0)
            {
                result = result.Where(x => x.User.FullName.Contains(FullNameUser) && x.Date.Equals(date) && x.Status.Equals(reserveStatus));
            }

            else if (
                 string.IsNullOrWhiteSpace(FullNameUser) &&
                 !string.IsNullOrWhiteSpace(FullNameEquipment) &&
                 date.HasValue &&
                 status != 0)
            {
                result = result.Where(x => x.Equipment.Name.Contains(FullNameEquipment) && x.Date.Equals(date) && x.Status.Equals(reserveStatus));
            }

            else if (string.IsNullOrWhiteSpace(FullNameUser) &&
                string.IsNullOrWhiteSpace(FullNameEquipment) &&
                date.HasValue &&
                status != 0)
            {
                result = result.Where(x => x.Date.Equals(date) && x.Status.Equals(reserveStatus));
            }

            else if (string.IsNullOrWhiteSpace(FullNameUser) &&
                string.IsNullOrWhiteSpace(FullNameEquipment) &&
                !date.HasValue &&
                status != 0)
            {
                result = result.Where(x => x.Status.Equals(reserveStatus));
            }

            else if (!string.IsNullOrWhiteSpace(FullNameUser) &&
             string.IsNullOrWhiteSpace(FullNameEquipment) &&
             !date.HasValue &&
             status != 0)
            {
                result = result.Where(x => x.Status.Equals(reserveStatus));
            }
            else if (string.IsNullOrWhiteSpace(FullNameUser) &&
               !string.IsNullOrWhiteSpace(FullNameEquipment) &&
               !date.HasValue &&
               status != 0)
            {
                result = result.Where(x => x.Status.Equals(reserveStatus));
            }

            else if (string.IsNullOrWhiteSpace(FullNameUser) &&
              !string.IsNullOrWhiteSpace(FullNameEquipment) &&
              !date.HasValue &&
              status == 0)
            {
                result = result.Where(x => x.Status.Equals(reserveStatus));
            }
            else if (!string.IsNullOrWhiteSpace(FullNameUser) &&
                string.IsNullOrWhiteSpace(FullNameEquipment) &&
                !date.HasValue &&
                status == 0)
            {
                result = result.Where(x => x.Status.Equals(reserveStatus));
            }

            result = result.OrderBy(d => d.Date).ThenBy(h => h.Schedule.HourInitial).Skip(offset).Take(size);

            return await result.ToListAsync();
        }

        public async Task<List<Reserver>> FindWithPagedSearchForUser(

            int id,
            string equipment,
            int size,
            int offset,
            DateTime? date,
            int status)
        {

            ReserveStatus reserveStatus = (ReserveStatus)status;

            IQueryable<Reserver> result = _context.Reservations
               .Include(c => c.User)
               .Include(e => e.Equipment)
               .Include(s => s.Schedule);

            //List reservations with  date, equipment and status;
            if (
                !string.IsNullOrWhiteSpace(equipment) &&
                date.HasValue &&
                status != 0)
            {
                result = result.Where(x => x.UserId.Equals(id) && x.Equipment.Name.Contains(equipment) && x.Date.Equals(date) && x.Status.Equals(reserveStatus));
            }

            //List reservations with  date and status;
            else if (
                string.IsNullOrWhiteSpace(equipment) &&
                date.HasValue &&
                status != 0)
            {
                result = result.Where(x => x.UserId.Equals(id) && x.Date.Equals(date) && x.Status.Equals(reserveStatus));
            }

            //List reservations with equipments and status;
            else if (
               !string.IsNullOrWhiteSpace(equipment) &&
               !date.HasValue &&
               status != 0)
            {
                result = result.Where(x => x.UserId.Equals(id) && x.Equipment.Name.Contains(equipment) && x.Status.Equals(reserveStatus));
            }

            //List reservations only with status
            else if (
               string.IsNullOrWhiteSpace(equipment) &&
               !date.HasValue &&
               status != 0)
            {
                result = result.Where(x => x.UserId.Equals(id) && x.Status.Equals(reserveStatus));
            }

            //List reservations only with equipments;
            else if (
               !string.IsNullOrWhiteSpace(equipment) &&
               !date.HasValue &&
               status == 0)
            {
                result = result.Where(x => x.UserId.Equals(id) && x.Equipment.Name.Contains(equipment));
            }

            //List reservations only with date;
            else if (
              string.IsNullOrWhiteSpace(equipment) &&
              date.HasValue &&
              status == 0)
            {
                result = result.Where(x => x.UserId.Equals(id) && x.Date.Equals(date));
            }

            //List reservations with equipment and date;
            else if (
               !string.IsNullOrWhiteSpace(equipment) &&
               date.HasValue &&
               status == 0)
            {
                result = result.Where(x => x.UserId.Equals(id) && x.Equipment.Name.Contains(equipment) && x.Date.Equals(date));
            }

            //List all reservations of user;
            else
            {
                result = result.Where(x => x.UserId.Equals(id));
            }
            result = result.OrderBy(d => d.Date).ThenBy(h => h.Schedule.HourInitial).Skip(offset).Take(size);
            return await result.ToListAsync();
        }

        public int GetCountResUser(int id, string FullNameEquipment, DateTime? date, int status)
        {
            ReserveStatus reserveStatus = (ReserveStatus)status;
            string nameEquipment = "";
            if (!string.IsNullOrWhiteSpace(FullNameEquipment))
            {
                nameEquipment = FullNameEquipment;
            }
            var result = _context.Reservations
               .Include(c => c.User)
               .Include(e => e.Equipment)
               .Include(s => s.Schedule);

            var countResult = date.HasValue ?
                (
               result.Where(x => x.UserId.Equals(id) &&
                     x.Equipment.Name.Contains(nameEquipment) &&
                     x.Date.Equals(date) &&
                     x.Status.Equals(reserveStatus))
               .Count()
                   ) : (

               result.Where(x => x.UserId.Equals(id) &&
                         x.Equipment.Name.Contains(nameEquipment) &&
                         x.Status.Equals(reserveStatus))
                   .Count()
           );

            return countResult;
        }

        public int GetCount(string name, string equipment, DateTime? date, int status)
        {
            ReserveStatus reserveStatus = (ReserveStatus)status;
            string fullName = "";
            string nameEquipment = "";
            if (!string.IsNullOrWhiteSpace(name))
            {
                fullName = name;
            }
            if (!string.IsNullOrWhiteSpace(equipment))
            {
                nameEquipment = equipment;
            }

            var result = _context.Reservations
                .Include(c => c.User)
                .Include(e => e.Equipment)
                .Include(s => s.Schedule);

            var countResult = date.HasValue ?
                 (
                        result.Where(x => x.User.FullName.Contains(fullName) &&
                     x.Equipment.Name.Contains(nameEquipment) &&
                     x.Date.Equals(date) &&
                     x.Status.Equals(reserveStatus))
                    .Count()
                    ) : (
                   result.Where(x => x.User.FullName.Contains(fullName) &&
                             x.Equipment.Name.Contains(nameEquipment) &&
                             x.Status.Equals(reserveStatus))
                            .Count()
            );

            return countResult;
        }
    }
}
