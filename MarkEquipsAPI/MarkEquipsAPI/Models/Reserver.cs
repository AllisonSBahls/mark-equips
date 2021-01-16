using System;
using System.Collections.Generic;

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
        public List<ReserverSchedule> ReserverSchedules { get; set; }
    }
}
