using MarkEquipsAPI.Models.Base;
using MarkEquipsAPI.Models.Enums;
using System;
using System.Collections.Generic;

namespace MarkEquipsAPI.Models
{
    public class Schedule : BaseEntity
    {

        public TimeSpan HourInitial { get; set; }
        public TimeSpan HourFinal { get; set; }
        public string Period { get; set; }
        public List<Reserver> Reservations { get; set; }

    }
}
