using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class TimeKeepingFeedback
    {
        public string TimeKeepingFeedbackId { get; set; }
        public string CheckinId { get; set; }
        [DisplayName("Comments")]
        public string Reason { get; set; }
        [DisplayName("Date")]
        public DateTime Time { get; set; }
        public string TimeOffRequestStateId { get; set; }
        public bool? Active { get; set; }

        public virtual Checkin Checkin { get; set; }
        [DisplayName("Status")]
        public virtual TimeOffRequestState TimeOffRequestState { get; set; }
    }
}
