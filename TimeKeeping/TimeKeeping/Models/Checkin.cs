using System;
using System.Collections.Generic;

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
        public DateTime Time { get; set; }

        public virtual Personnel Personnel { get; set; }
        public virtual ICollection<TimeKeepingFeedback> TimeKeepingFeedbacks { get; set; }
    }
}
