using MarkEquipsAPI.Hypermedia;
using MarkEquipsAPI.Hypermedia.Abstract;
using MarkEquipsAPI.Models;
using System;
using System.Collections.Generic;

namespace MarkEquipsAPI.Data.DTOs
{
    public class ReservedDto
    {
        public DateTime Date { get; set; }
        public int Status { get; set;}
        public int ScheduleId { get; set; }
    }


}
