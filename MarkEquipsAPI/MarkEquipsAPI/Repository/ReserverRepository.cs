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
         
                Console.WriteLine("---------- " + IsValidation(1, 7, new DateTime(2021, 01, 10)) + "---------- ");

            var reservations =  _context.Reservations
                .Include(rs => rs.Schedules)
                   .ThenInclude(s => s.Schedule);

            return await reservations.AsNoTracking().ToListAsync();
            
        }

        /*
        public async Task<Reserver> Reserver(Reserver reserver)
        {

            _context.Reservations.Add(reserver);
            
            await _context.SaveChangesAsync();
            return reserver;
        }*/

        /*
         Validando a reserva dos equipcamentos na API,
         Primeiro é feito a verificação dos equipamentos se na data e horário solicitado está disponivel o equipamento
         Caso não esteja disponivel será retornado um erro de inserção
         */
        public bool IsValidation(int equipId, int schedId, DateTime date)
        {
            var validateIdEquips = _context.ReserverSchedules
                .Include(rs => rs.Schedule)
                .Include(r => r.Reserver).Where(r => r.Reserver.EquipmentId.Equals(equipId));

            var validateHours = validateIdEquips.Where(s => s.ScheduleId.Equals(schedId));

            var validatData = validateIdEquips.Where(s => s.Reserver.Date.Equals(date));

            if (validateIdEquips.Any() && validateHours.Any() && validatData.Any())
            {
                Console.WriteLine("Não é possivel reserver o equipamento para esse horário por o mesmo já esta reservado, escolha outra outro horário ou outra data");
                return true;
            }
            else
            {
                Console.WriteLine("Equipamento disponivel para esse horário");
                return false;
            }
        }
    }
}
