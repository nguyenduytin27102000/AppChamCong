using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class Personnel
    {
        public Personnel()
        {
            Checkins = new HashSet<Checkin>();
            PersonnelApplyTimeOffPolicies = new HashSet<PersonnelApplyTimeOffPolicy>();
            TimeOffApprovers = new HashSet<TimeOffApprover>();
            TimeOffFollowers = new HashSet<TimeOffFollower>();
            TimeOffRequestManagers = new HashSet<TimeOffRequest>();
            TimeOffRequestPersonnel = new HashSet<TimeOffRequest>();
        }

        public string PersonnelId { get; set; }

        [Display(Name = "First name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
            ErrorMessage = "Characters are not allowed.")]
        [Required(ErrorMessage = "Please enter first name!")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
            ErrorMessage = "Characters are not allowed.")]
        [Required(ErrorMessage = "Please enter last name!")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get => $"{FirstName} {LastName}"; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter email!")]
        public string Email { get; set; }

        [Display(Name = "Office")]
        public string OfficeId { get; set; }

        [Display(Name = "Work schedule")]
        public string WorkScheduleId { get; set; }

        [Display(Name = "Working area")]
        public string WorkingAreaId { get; set; }

        [Display(Name = "Position")]
        public string PositionId { get; set; }

        [Display(Name = "Salary policy")]
        public string SalaryPolicyId { get; set; }

        [Display(Name = "Type personnel")]
        public string TypePersonnelId { get; set; }

        [Required(ErrorMessage = "Please enter title!")]
        public string Title { get; set; }

        [Display(Name = "Actual salary")]
        [Required(ErrorMessage = "Please enter actual salary!")]
        public decimal ActualSalary { get; set; }

        [Display(Name = "Basic salary")]
        [Required(ErrorMessage = "Please enter basic salary!")]
        public decimal BasicSalary { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Official date")]
        public DateTime? OfficialDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public bool Sex { get; set; }

        [Display(Name = "Personal address")]
        [Required(ErrorMessage = "Please enter personnel address!")]
        public string PersonnelAddress { get; set; }
        public bool? Active { get; set; }

        public virtual Office Office { get; set; }
        public virtual Position Position { get; set; }
        public virtual SalaryPolicy SalaryPolicy { get; set; }
        public virtual TypePersonnel TypePersonnel { get; set; }
        public virtual WorkSchedule WorkSchedule { get; set; }
        public virtual WorkingArea WorkingArea { get; set; }
        public virtual ICollection<Checkin> Checkins { get; set; }
        public virtual ICollection<PersonnelApplyTimeOffPolicy> PersonnelApplyTimeOffPolicies { get; set; }
        public virtual ICollection<TimeOffApprover> TimeOffApprovers { get; set; }
        public virtual ICollection<TimeOffFollower> TimeOffFollowers { get; set; }
        public virtual ICollection<TimeOffRequest> TimeOffRequestManagers { get; set; }
        public virtual ICollection<TimeOffRequest> TimeOffRequestPersonnel { get; set; }
    }
}
