using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class WorkingArea
    {
        public WorkingArea()
        {
            Personnel = new HashSet<Personnel>();
            Positions = new HashSet<Position>();
            WorkingAreaApplyFormTimeOffs = new HashSet<WorkingAreaApplyFormTimeOff>();
        }

        public string WorkingAreaId { get; set; }
        public string WorkingAreaName { get; set; }
        public string Describe { get; set; }
        public bool? States { get; set; }
        public bool? Del { get; set; }

        public virtual ICollection<Personnel> Personnel { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
        public virtual ICollection<WorkingAreaApplyFormTimeOff> WorkingAreaApplyFormTimeOffs { get; set; }
    }
}
