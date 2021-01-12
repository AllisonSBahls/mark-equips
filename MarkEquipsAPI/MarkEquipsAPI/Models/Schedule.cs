using MarkEquipsAPI.Models.Base;
using MarkEquipsAPI.Models.Enums;
using System;
using System.Collections.Generic;

namespace MarkEquipsAPI.Models
{
    public class Schedule : BaseEntity
    {

        public string HourInitial { get; set; }
        public string HourFinal { get; set; }
        public PeriodDay Period { get; set; }
        public List<ReserverSchedule> Reserves { get; set; }
    }
}
