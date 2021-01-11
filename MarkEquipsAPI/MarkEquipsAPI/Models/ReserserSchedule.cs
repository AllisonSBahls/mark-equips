namespace MarkEquipsAPI.Models
{
    public class ReserserSchedule
    {
        public int ReserverId { get; set; }
        public Reserver Reserver { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}