using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace TimeKeeping.Models
{
    public partial class TimeKeepingFeedback
    {
        public string TimeKeepingFeedbackId { get; set; }
        public string CheckinId { get; set; }
        [Display(Name = "Comments")]
        public string Reason { get; set; }
        [Display(Name = "Date")]
        public DateTime Time { get; set; }
        public string TimeOffRequestStateId { get; set; }
        public bool? Active { get; set; }

        public virtual Checkin Checkin { get; set; }
        [Display(Name = "Status")]
        public virtual TimeOffRequestState TimeOffRequestState { get; set; }
    }
}
