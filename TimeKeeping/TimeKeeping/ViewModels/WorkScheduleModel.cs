using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TimeKeeping.Models;

namespace TimeKeeping.ViewModels
{
    [BindProperties]
    public class WorkScheduleModel
    {
        [Display(Name = "Work schedule ID")]
        public string WorkScheduleId { get; set; }

        [Display(Name = "Work schedule name")]
        public string WorkScheduleName { get; set; }

        [Display(Name = "Work schedule type")]
        public string TypeWorkScheduleId { get; set; }

        [Display(Name = "Require checkout")]
        public bool? RequireCheckout { get; set; }

        [Display(Name = "Working hours per Day")]
        public byte WorkingHoursPerDay { get; set; }

        [Display(Name = "Minutes late")]
        public byte MinutesLate { get; set; }

        [Display(Name = "Minutes early")]
        public byte MinutesEarly { get; set; }

        public string Regulations { get; set; }

        [Display(Name = "Start date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public bool? States { get; set; }
        public bool? Active { get; set; }

        public virtual TypeWorkSchedule TypeWorkSchedule { get; set; }
        public virtual ICollection<Personnel> Personnel { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }

    }
}
