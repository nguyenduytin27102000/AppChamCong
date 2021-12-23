using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TimeKeeping.CustomValidation.Personnels;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class Personnel
    {
        public Personnel()
        {
            PersonnelApplyTimeOffPolicies = new HashSet<PersonnelApplyTimeOffPolicy>();
            TimeOffApprovers = new HashSet<TimeOffApprover>();
            TimeOffFollowers = new HashSet<TimeOffFollower>();
            TimeOffRequestManagers = new HashSet<TimeOffRequest>();
            TimeOffRequestPersonnel = new HashSet<TimeOffRequest>();
        }

        [Display(Name = "Personnel ID")]
        [Required(ErrorMessage = "Please enter Personnel ID!")]
        public string PersonnelId { get; set; }

        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
            ErrorMessage = "Characters are not allowed.")]
        [Required(ErrorMessage = "Please enter first name!")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
            ErrorMessage = "Characters are not allowed.")]
        [Required(ErrorMessage = "Please enter last name!")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get => $"{LastName}  {FirstName}"; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter email!")]
        public string Email { get; set; }

        [Display(Name = "Office")]
        public string OfficeId { get; set; }

        [Display(Name = "Work Schedule")]
        public string WorkScheduleId { get; set; }

        [Display(Name = "Working Area")]
        public string WorkingAreaId { get; set; }

        [Display(Name = "Position")]
        public string PositionId { get; set; }

        [Display(Name = "Salary Policy")]
        public string SalaryPolicyId { get; set; }

        [Display(Name = "Type Personnel")]
        public string TypePersonnelId { get; set; }

        [Required(ErrorMessage = "Please enter title!")]
        public string Title { get; set; }

        [Display(Name = "Actual Salary")]
        [Required(ErrorMessage = "Please enter actual salary!")]
        public decimal ActualSalary { get; set; }

        [Display(Name = "Basic Salary")]
        [Required(ErrorMessage = "Please enter basic salary!")]
        public decimal BasicSalary { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Official Date")]
        public DateTime? OfficialDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public bool Sex { get; set; }

        [Display(Name = "Personal Address")]
        [Required(ErrorMessage = "Please enter personnel address!")]
        public string PersonnelAddress { get; set; }

        public bool? Del { get; set; }

        public virtual Office Office { get; set; }
        public virtual Position Position { get; set; }

        [Display(Name = "Salary Policy")]
        public virtual SalaryPolicy SalaryPolicy { get; set; }

        [Display(Name = "Type Personnel")]
        public virtual TypePersonnel TypePersonnel { get; set; }

        [Display(Name = "WorkSchedule")]
        public virtual WorkSchedule WorkSchedule { get; set; }

        [Display(Name = "Working Area")]
        public virtual WorkingArea WorkingArea { get; set; }
        public virtual ICollection<PersonnelApplyTimeOffPolicy> PersonnelApplyTimeOffPolicies { get; set; }
        public virtual ICollection<TimeOffApprover> TimeOffApprovers { get; set; }
        public virtual ICollection<TimeOffFollower> TimeOffFollowers { get; set; }
        public virtual ICollection<TimeOffRequest> TimeOffRequestManagers { get; set; }
        public virtual ICollection<TimeOffRequest> TimeOffRequestPersonnel { get; set; }
    }
}