using System;
using System.Collections.Generic;

#nullable disable

namespace CreateRequestTimeoffForm_Version1.Models
{
    public partial class DaysOfWeek
    {
        public DaysOfWeek()
        {
            Shifts = new HashSet<Shift>();
        }

        public string DaysOfWeekId { get; set; }
        public string DaysOfWeekName { get; set; }
        public bool? Del { get; set; }

        public virtual ICollection<Shift> Shifts { get; set; }
    }
}
