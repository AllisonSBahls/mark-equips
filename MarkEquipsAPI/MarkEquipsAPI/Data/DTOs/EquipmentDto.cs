using MarkEquipsAPI.Hypermedia;
using MarkEquipsAPI.Hypermedia.Abstract;
using System;
using System.Collections.Generic;

namespace MarkEquipsAPI.Data.DTOs
{
    public class EquipmentDto : ISupportsHyperMedia
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public string ImageURL { get; set; }
        public int QtyReserservation { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

    }
}
