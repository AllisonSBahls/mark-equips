using MarkEquipsAPI.Models.Enums;
using System;
using System.Collections.Generic;

namespace MarkEquipsAPI.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public TimeSpan HourInitial { get; set; }
        public TimeSpan HourFinal { get; set; }
        public PeriodDay Period { get; set; }
        public List<ReserserSchedule> Reserves { get; set; }
    }
}
