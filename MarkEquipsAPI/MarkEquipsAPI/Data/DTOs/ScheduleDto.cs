using MarkEquipsAPI.Hypermedia;
using MarkEquipsAPI.Hypermedia.Abstract;
using System.Collections.Generic;

namespace MarkEquipsAPI.Data.DTOs
{
    public class ScheduleDto : ISupportsHyperMedia
    {
        public int Id { get; set; }
        public string HourInitial { get; set; }
        public string HourFinal { get; set; }
        public string Period { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

    }

    public class SchedulesReserverDto
    {
        public string HourInitial { get; set; }
        public string HourFinal { get; set; }
        public string Period { get; set; }
    }
}
