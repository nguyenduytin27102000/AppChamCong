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
        [Display(Name = "Work Schedule ID")]
        public string WorkScheduleId { get; set; }

        [Display(Name = "Work Schedule Name")]
        public string WorkScheduleName { get; set; }

        [Display(Name = "Type Work Schedule")]
        public string TypeWorkScheduleId { get; set; }

        [Display(Name = "Checkin Policy")]
        public string CheckinPolicyId { get; set; }

        [Display(Name = "Number of Shift")]
        public string NumberOfShiftId { get; set; }

        [Display(Name = "Require Checkout")]
        public bool? RequireCheckout { get; set; }

        [Display(Name = "Working Hours Per Day")]
        public byte WorkingHoursPerDay { get; set; }

        [Display(Name = "Minutes Late")]
        public byte MinutesLate { get; set; }
        
        [Display(Name = "Minutes Early")]
        public byte MinutesEarly { get; set; }

        public string Regulations { get; set; }
        public bool? States { get; set; }
        public bool? Del { get; set; }

        public virtual CheckinPolicy CheckinPolicy { get; set; }
        public virtual NumberOfShift NumberOfShift { get; set; }
        public virtual TypeWorkSchedule TypeWorkSchedule { get; set; }
        public virtual ICollection<Personnel> Personnel { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }
    }
}
