using System;
using System.Collections.Generic;

#nullable disable

namespace CreateRequestTimeoffForm_Version1.Models
{
    public partial class TypeWorkSchedule
    {
        public TypeWorkSchedule()
        {
            WorkSchedules = new HashSet<WorkSchedule>();
        }

        public string TypeWorkScheduleId { get; set; }
        public string TypeWorkScheduleName { get; set; }
        public bool? Del { get; set; }

        public virtual ICollection<WorkSchedule> WorkSchedules { get; set; }
    }
}
