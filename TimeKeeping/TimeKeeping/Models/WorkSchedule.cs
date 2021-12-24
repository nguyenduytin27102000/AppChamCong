using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class WorkSchedule
    {
        public WorkSchedule()
        {
            Personnel = new HashSet<Personnel>();
            Shifts = new HashSet<Shift>();
        }

        public string WorkScheduleId { get; set; }
        public string WorkScheduleName { get; set; }
        public string TypeWorkScheduleId { get; set; }
        public string CheckinPolicyId { get; set; }
        public string NumberOfShiftId { get; set; }
        public bool? RequireCheckout { get; set; }
        public byte WorkingHoursPerDay { get; set; }
        public byte MinutesLate { get; set; }
        public byte MinutesEarly { get; set; }
        public string Regulations { get; set; }
        public bool? States { get; set; }
        public bool? Active { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual CheckinPolicy CheckinPolicy { get; set; }
        public virtual NumberOfShift NumberOfShift { get; set; }
        public virtual TypeWorkSchedule TypeWorkSchedule { get; set; }
        public virtual ICollection<Personnel> Personnel { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }
    }
}
