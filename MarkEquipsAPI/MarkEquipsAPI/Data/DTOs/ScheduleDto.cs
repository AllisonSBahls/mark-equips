using MarkEquipsAPI.Models.Enums;
using System.Collections.Generic;

namespace MarkEquipsAPI.Data.DTO
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public string HourInitial { get; set; }
        public string HourFinal { get; set; }
        public int Period { get; set; }
        public List<ReserverDto> Reserves { get; set; }

    }
}
