﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CreateRequestTimeoffForm_Version1.Models
{
    public partial class Shift
    {
        public Shift()
        {
            TimeOffShifts = new HashSet<TimeOffShift>();
        }

        public string WorkScheduleId { get; set; }
        public string DaysOfWeekId { get; set; }
        public string ShiftId { get; set; }
        public string TypeShiftId { get; set; }
        public string ShiftName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool? DayOff { get; set; }
        public bool? Del { get; set; }

        public virtual DaysOfWeek DaysOfWeek { get; set; }
        public virtual TypeShift TypeShift { get; set; }
        public virtual WorkSchedule WorkSchedule { get; set; }
        public virtual ICollection<TimeOffShift> TimeOffShifts { get; set; }
    }
}
