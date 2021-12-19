using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class TypeShift
    {
        public TypeShift()
        {
            Shifts = new HashSet<Shift>();
        }

        public string TypeShiftId { get; set; }
        public string TypeShiftName { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Shift> Shifts { get; set; }
    }
}
