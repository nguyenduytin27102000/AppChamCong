using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class TimeOffRequest
    {
        public TimeOffRequest()
        {
            DayOffs = new HashSet<DayOff>();
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
        public DateTime TimeOffDate { get; set; } = DateTime.Now;
        public string TimeOffRequestStateId { get; set; }
        public string Feedback { get; set; } = string.Empty;
        public bool? Del { get; set; } = false;

        public virtual FormTimeOff FormTimeOff { get; set; }
        public virtual Personnel Manager { get; set; }
        public virtual Personnel Personnel { get; set; }
        public virtual TimeOffRequestState TimeOffRequestState { get; set; }
        public virtual ICollection<DayOff> DayOffs { get; set; }
    }
}
