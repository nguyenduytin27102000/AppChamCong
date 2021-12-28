using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class TimeOffRequestState
    {
        public TimeOffRequestState()
        {
            TimeKeepingFeedbacks = new HashSet<TimeKeepingFeedback>();
            TimeOffRequests = new HashSet<TimeOffRequest>();
        }

        public string TimeOffRequestStateId { get; set; }
        public string TimeOffRequestStateName { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<TimeKeepingFeedback> TimeKeepingFeedbacks { get; set; }
        public virtual ICollection<TimeOffRequest> TimeOffRequests { get; set; }
    }
}
