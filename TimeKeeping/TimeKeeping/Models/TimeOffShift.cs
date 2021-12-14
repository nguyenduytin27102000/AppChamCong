using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class TimeOffShift
    {
        public string DayOffId { get; set; }
        public string TimeOffRequestId { get; set; }
        public string ShiftId { get; set; }
        public bool? Del { get; set; }

        public virtual DayOff DayOff { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual TimeOffRequest TimeOffRequest { get; set; }
    }
}
