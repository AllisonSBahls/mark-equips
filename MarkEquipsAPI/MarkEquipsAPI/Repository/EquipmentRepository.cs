using MarkEquipsAPI.Models;
using MarkEquipsAPI.Repository.Context;
using MarkEquipsAPI.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Repository
{
    public class EquipmentRepository : GenericRepository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(MarkEquipsContext context) : base(context) { }

        public int GetCountEquipReserves(int id)
        {
            return _context.Reservations.Where(x => x.EquipmentId.Equals(id)).Count();
        }
    }
}
