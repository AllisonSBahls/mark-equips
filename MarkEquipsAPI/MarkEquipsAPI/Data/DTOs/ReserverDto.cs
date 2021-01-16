using System;
using System.Collections.Generic;

namespace MarkEquipsAPI.Data.DTOs
{
    public class ReserverDto
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CollaboratorId { get; set; }
        public CollaboratorDto Collaborator { get; set; }
        public int EquipmentId { get; set; }
        public EquipmentDto Equipment { get; set; }
        public int ScheduleId { get; set; }
        public ScheduleDto Schedules { get; set; }
    }

   
}
