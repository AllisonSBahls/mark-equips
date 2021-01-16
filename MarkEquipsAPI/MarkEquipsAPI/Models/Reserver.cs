using MarkEquipsAPI.Models.Enums;
using System;

namespace MarkEquipsAPI.Models
{
    public class Reserver
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CollaboratorId { get; set; }
        public Collaborator Collaborator { get; set; }
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public ReserveStatus Status { get; set; }
    }
}
