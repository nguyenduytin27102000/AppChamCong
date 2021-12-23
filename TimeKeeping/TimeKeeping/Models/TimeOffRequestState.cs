using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class TimeOffRequestState
    {
        public TimeOffRequestState()
        {
            TimeOffRequests = new HashSet<TimeOffRequest>();
        }

        public string TimeOffRequestStateId { get; set; }
        public string TimeOffRequestStateName { get; set; }
        public bool? Del { get; set; }

        public virtual ICollection<TimeOffRequest> TimeOffRequests { get; set; }
    }
}
