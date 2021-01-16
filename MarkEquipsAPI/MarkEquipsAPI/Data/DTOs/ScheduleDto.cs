using MarkEquipsAPI.Models.Enums;
using System.Collections.Generic;

namespace MarkEquipsAPI.Data.DTOs
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public string HourInitial { get; set; }
        public string HourFinal { get; set; }
        public int Period { get; set; }
        public int Status { get; set; }


    }
}
