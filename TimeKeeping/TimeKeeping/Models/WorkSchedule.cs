using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Work schedule id")]
        public string WorkScheduleId { get; set; }

        [Display(Name = "Work schedule name")]
        public string WorkScheduleName { get; set; }

        [Display(Name = "Work schedule type")]
        public string TypeWorkScheduleId { get; set; }

        public string CheckinPolicyId { get; set; }

        public string NumberOfShiftId { get; set; }

        [Display(Name = "Require checkout")]
        public bool? RequireCheckout { get; set; }

        [Display(Name = "Working hours per day")]
        public byte WorkingHoursPerDay { get; set; }

        [Display(Name = "Minutes late")]
        public byte MinutesLate { get; set; }

        [Display(Name = "Minutes early")]
        public byte MinutesEarly { get; set; }
        public string Regulations { get; set; }
        public bool? States { get; set; }
        public bool? Active { get; set; }

        [Display(Name = "Start date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public virtual CheckinPolicy CheckinPolicy { get; set; }
        public virtual NumberOfShift NumberOfShift { get; set; }
        public virtual TypeWorkSchedule TypeWorkSchedule { get; set; }
        public virtual ICollection<Personnel> Personnel { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }
    }
}
