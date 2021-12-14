using System;
using System.Collections.Generic;

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

        public string FormTimeOffId { get; set; }
        public string FormTimeOffName { get; set; }
        public string TypeTimeOffId { get; set; }
        public bool? RequireApproval { get; set; }
        public string ApprovalProcessId { get; set; }
        public bool? RequireLimitedDaysOff { get; set; }
        public byte? ProcessingTime { get; set; }
        public byte? NumberOfDaysBeforeTimeOff { get; set; }
        public byte? LimitedDaysOff { get; set; }
        public string Regulations { get; set; }
        public bool? Del { get; set; }

        public virtual ApprovalProcess ApprovalProcess { get; set; }
        public virtual TypeTimeOff TypeTimeOff { get; set; }
        public virtual ICollection<TimeOffApprover> TimeOffApprovers { get; set; }
        public virtual ICollection<TimeOffFollower> TimeOffFollowers { get; set; }
        public virtual ICollection<TimeOffRequest> TimeOffRequests { get; set; }
        public virtual ICollection<WorkingAreaApplyFormTimeOff> WorkingAreaApplyFormTimeOffs { get; set; }
    }
}
