using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class DayOff
    {
        public string DayOffId { get; set; }
        public string TimeOffRequestId { get; set; }
        public DateTime DayOffAt { get; set; }
        public string FromHour { get; set; }
        public string ToHour { get; set; }
        public bool? Active { get; set; }

        public virtual TimeOffRequest TimeOffRequest { get; set; }
    }
}
