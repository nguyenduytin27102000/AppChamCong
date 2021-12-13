using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class DayOff
    {
        public DayOff()
        {
            TimeOffShifts = new HashSet<TimeOffShift>();
        }

        public string DayOffId { get; set; }
        public string TimeOffRequestId { get; set; }
        public DateTime DayOff1 { get; set; }
        public bool? Del { get; set; }

        public virtual TimeOffRequest TimeOffRequest { get; set; }
        public virtual ICollection<TimeOffShift> TimeOffShifts { get; set; }
    }
}
