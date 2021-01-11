using System;
using System.Collections.Generic;
using MarkEquipsAPI.Models.Base;
using MarkEquipsAPI.Models.Enums;

namespace MarkEquipsAPI.Models
{
    public class Reserver : BaseEntity
    {
        public DateTime Date { get; set; }
        public ReserveStatus Status { get; set; }
        public int CollaboratorId { get; set; }
        public Collaborator Collaborator { get; set; }
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
        public List<ReserserSchedule> Schedules { get; set; }
    }
}
