﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class TimeOffRequest
    {
        public TimeOffRequest()
        {
            DayOffs = new HashSet<DayOff>();
            TimeOffShifts = new HashSet<TimeOffShift>();
        }

        public string PersonnelId { get; set; }
        public string TimeOffRequestId { get; set; }
        public string Title { get; set; }
        public string FormTimeOffId { get; set; }
        public string Reason { get; set; }
        public bool RequireHandOver { get; set; }
        public string HandOverWorks { get; set; }
        public string ManagerId { get; set; }
        public string Attachment { get; set; }
        public DateTime TimeOffDate { get; set; }
        public string States { get; set; }
        public string Feedback { get; set; }
        public bool? Del { get; set; }

        public virtual FormTimeOff FormTimeOff { get; set; }
        public virtual Personnel Manager { get; set; }
        public virtual Personnel Personnel { get; set; }
        public virtual ICollection<DayOff> DayOffs { get; set; }
        public virtual ICollection<TimeOffShift> TimeOffShifts { get; set; }
    }
}
