using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class NumberOfShift
    {
        public NumberOfShift()
        {
            WorkSchedules = new HashSet<WorkSchedule>();
        }

        public string NumberOfShiftId { get; set; }
        public byte Count { get; set; }
        public bool? Del { get; set; }

        public virtual ICollection<WorkSchedule> WorkSchedules { get; set; }
    }
}
