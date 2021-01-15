using System;
using System.Collections.Generic;

namespace MarkEquipsAPI.Data.DTO
{
    public class ReserverDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public int CollaboratorId { get; set; }

         public CollaboratorDto Collaborator { get; set; }
        public int EquipmentId { get; set; }
         public EquipmentDto Equipment { get; set; }
        public List<ScheduleDto> Schedules { get; set; }

    }

   
}
