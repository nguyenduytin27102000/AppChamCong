using System;
using System.ComponentModel.DataAnnotations;

namespace TimeKeeping.Models
{
    public class TimeKeepingFeedbackWithView
    {
        public string TimeKeepingFeedbackId { get; set; }
        public string CheckinId { get; set; }
        [Display(Name = "Comments")]
        public string Reason { get; set; }
        [Display(Name = "Date")]
        public DateTime Time { get; set; }
        public string TimeOffRequestStateId { get; set; }
        public bool? Active { get; set; }
      
        [Display(Name = "Status")]
        public  string TimeOffRequestStateName { get; set; }
        
        public string PersonnelId { get; set; }

        [Display(Name = "Employee Name")]
        public string LastName { get; set; }
    }
}
