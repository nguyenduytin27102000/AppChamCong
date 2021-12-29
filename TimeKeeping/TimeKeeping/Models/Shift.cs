using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class Shift
    {
        public string WorkScheduleId { get; set; }

        [Display(Name = "Day of week")]
        public string DaysOfWeekId { get; set; }

        public string ShiftId { get; set; }

        public string TypeShiftId { get; set; }

        [Display(Name = "Shift name")]
        public string ShiftName { get; set; }

        [Display(Name = "Start time")]
        public DateTime StartTime { get; set; }

        [Display(Name = "End time")]
        public DateTime EndTime { get; set; }
        public bool? DayOff { get; set; }
        public bool? Active { get; set; }

        public virtual DaysOfWeek DaysOfWeek { get; set; }
        public virtual TypeShift TypeShift { get; set; }
        public virtual WorkSchedule WorkSchedule { get; set; }
    }
}
