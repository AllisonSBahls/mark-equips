using MarkEquipsAPI.Models.Enums;

namespace MarkEquipsAPI.Models
{
    public class ReserverSchedule
    {
        public int ReserverId { get; set; }
        public virtual Reserver Reserver { get; set; }
        public int ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }
        public ReserveStatus Status { get; set; }

    }
}
