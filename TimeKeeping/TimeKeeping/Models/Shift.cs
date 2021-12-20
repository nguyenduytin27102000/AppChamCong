using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class Shift
    {
        public string WorkScheduleId { get; set; }
        public string DaysOfWeekId { get; set; }
        public string ShiftId { get; set; }
        public string ShiftName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool? Del { get; set; }

        public virtual DaysOfWeek DaysOfWeek { get; set; }
        public virtual WorkSchedule WorkSchedule { get; set; }
    }
}
