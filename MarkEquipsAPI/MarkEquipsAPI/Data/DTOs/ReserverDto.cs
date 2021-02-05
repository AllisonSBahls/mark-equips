using MarkEquipsAPI.Hypermedia;
using MarkEquipsAPI.Hypermedia.Abstract;
using MarkEquipsAPI.Models;
using System;
using System.Collections.Generic;

namespace MarkEquipsAPI.Data.DTOs
{
    public class ReserverDto : ISupportsHyperMedia
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }
        public UserReserverDto User { get; set; }
        public int EquipmentId { get; set; }
        public EquipmentReserverDto Equipment { get; set; }
        public int ScheduleId { get; set; }
        public SchedulesReserverDto Schedule { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }





}
