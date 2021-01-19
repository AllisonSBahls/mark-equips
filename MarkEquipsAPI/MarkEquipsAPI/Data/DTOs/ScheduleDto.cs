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
        public int Period { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

    }
}
