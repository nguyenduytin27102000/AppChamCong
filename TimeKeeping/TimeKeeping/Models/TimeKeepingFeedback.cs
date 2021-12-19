using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class TimeKeepingFeedback
    {
        public string TimeKeepingFeedbackId { get; set; }
        public string CheckinId { get; set; }
        public string Reason { get; set; }
        public DateTime Time { get; set; }
        public string TimeOffRequestStateId { get; set; }
        public bool? Active { get; set; }

        public virtual Checkin Checkin { get; set; }
        public virtual TimeOffRequestState TimeOffRequestState { get; set; }
    }
}
