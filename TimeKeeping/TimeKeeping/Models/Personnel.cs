using System;
using System.Collections.Generic;
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName { get => $"{FirstName} {LastName}"; }
        public string Email { get; set; }
        public string OfficeId { get; set; }
        public string WorkScheduleId { get; set; }
        public string WorkingAreaId { get; set; }
        public string PositionId { get; set; }
        public string SalaryPolicyId { get; set; }
        public string TypePersonnelId { get; set; }
        public string Title { get; set; }
        public decimal ActualSalary { get; set; }
        public decimal BasicSalary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? OfficialDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public bool Sex { get; set; }
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
