using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class CheckinPolicy
    {
        public CheckinPolicy()
        {
            WorkSchedules = new HashSet<WorkSchedule>();
        }

        public string CheckinPolicyId { get; set; }
        public string CheckinPolicyName { get; set; }
        public bool? Del { get; set; }

        public virtual ICollection<WorkSchedule> WorkSchedules { get; set; }
    }
}
