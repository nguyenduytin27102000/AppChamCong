using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class TypeWorkSchedule
    {
        public TypeWorkSchedule()
        {
            WorkSchedules = new HashSet<WorkSchedule>();
        }

        public string TypeWorkScheduleId { get; set; }
        public string TypeWorkScheduleName { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<WorkSchedule> WorkSchedules { get; set; }
    }
}
