using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Models
{
    public class ReserverSchedule
    {
        public int ReserverId { get; set; }
        public Reserver Reserver { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}
