using MarkEquipsAPI.Models;
using System;
using System.Collections.Generic;

namespace MarkEquipsAPI.Data.DTOs
{
    public class ReserverDto
    {

        CollaboratorDto cd = new CollaboratorDto();

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CollaboratorId { get; set; }
        public string Collaborator { get; set; }
        public int EquipmentId { get; set; }
        public string Equipment { get; set; }
        public string NumberEquipment { get; set; }
        public int Status { get; set;}
        public int ScheduleId { get; set; }
        public ScheduleDto Schedule { get; set; }


    }

   
}
