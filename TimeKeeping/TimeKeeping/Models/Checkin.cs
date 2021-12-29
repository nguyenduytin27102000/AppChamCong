using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class Checkin
    {
        public Checkin()
        {
            TimeKeepingFeedbacks = new HashSet<TimeKeepingFeedback>();
        }

        public string CheckinId { get; set; }
        public string PersonnelId { get; set; }
        [DisplayName("Date")]
        public DateTime Time { get; set; }
        public bool? Active { get; set; }
        [DisplayName("Person")]

        public virtual Personnel Personnel { get; set; }
        [DisplayName("Feedbacks")]
        public virtual ICollection<TimeKeepingFeedback> TimeKeepingFeedbacks { get; set; }
    }
}
