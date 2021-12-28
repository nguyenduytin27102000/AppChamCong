using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class FormTimeOff
    {
        public FormTimeOff()
        {
            TimeOffApprovers = new HashSet<TimeOffApprover>();
            TimeOffFollowers = new HashSet<TimeOffFollower>();
            TimeOffRequests = new HashSet<TimeOffRequest>();
            WorkingAreaApplyFormTimeOffs = new HashSet<WorkingAreaApplyFormTimeOff>();
        }
        [DisplayName("Form ID")]
        [Required(ErrorMessage = "This field is requied")]
        public string FormTimeOffId { get; set; }
        [DisplayName("Name")]
        [Required(ErrorMessage = "This field is requied")]
        public string FormTimeOffName { get; set; }
        [DisplayName("Type Time Off")]
        [Required(ErrorMessage = "This field is requied")]
        public string TypeTimeOffId { get; set; }
        [DisplayName("Require Approval")]
        [Required(ErrorMessage = "This field is requied")]
        public bool? RequireApproval { get; set; }
        [DisplayName("Approval Request Type")]
        [Required(ErrorMessage = "This field is requied")]
        public string ApprovalProcessId { get; set; }
        [DisplayName("Require Limited Days Off")]
        [Required(ErrorMessage = "This field is requied")]
        public bool? RequireLimitedDaysOff { get; set; }
        [DisplayName("Processing Time(time)")]
        [Required(ErrorMessage = "This field is requied")]
        public byte? ProcessingTime { get; set; }
        [DisplayName("Number Of Days Before Time Off(Days)")]
        [Required(ErrorMessage = "This field is requied")]
        public byte? NumberOfDaysBeforeTimeOff { get; set; }
        [DisplayName("Limited Days Off(Days)")]
        [Required(ErrorMessage = "This field is requied")]
        public byte? LimitedDaysOff { get; set; }
        [DisplayName("Regulations")]
        [Required(ErrorMessage = "This field is requied")]
        public string Regulations { get; set; }
        public bool? Active { get; set; }


        public virtual ApprovalProcess ApprovalProcess { get; set; }
        public virtual TypeTimeOff TypeTimeOff { get; set; }
        public virtual ICollection<TimeOffApprover> TimeOffApprovers { get; set; }
        public virtual ICollection<TimeOffFollower> TimeOffFollowers { get; set; }
        public virtual ICollection<TimeOffRequest> TimeOffRequests { get; set; }
        public virtual ICollection<WorkingAreaApplyFormTimeOff> WorkingAreaApplyFormTimeOffs { get; set; }
    }
}
