using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class WorkingAreaApplyFormTimeOff
    {
        public string WorkingAreaId { get; set; }
        public string FormTimeOffId { get; set; }
        public bool? Del { get; set; }

        public virtual FormTimeOff FormTimeOff { get; set; }
        public virtual WorkingArea WorkingArea { get; set; }
    }
}
