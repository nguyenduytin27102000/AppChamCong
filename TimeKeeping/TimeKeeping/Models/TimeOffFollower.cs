using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class TimeOffFollower
    {
        public string PersonnelId { get; set; }
        public string FormTimeOffId { get; set; }
        public bool? Active { get; set; }

        public virtual FormTimeOff FormTimeOff { get; set; }
        public virtual Personnel Personnel { get; set; }
    }
}
