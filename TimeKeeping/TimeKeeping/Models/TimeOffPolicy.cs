using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class TimeOffPolicy
    {
        public TimeOffPolicy()
        {
            ApplySeniorityPolicies = new HashSet<ApplySeniorityPolicy>();
            PersonnelApplyTimeOffPolicies = new HashSet<PersonnelApplyTimeOffPolicy>();
        }

        public string TimeOffPolicyId { get; set; }
        public string TimeOffPolicyName { get; set; }
        public string TypePolicyId { get; set; }
        public byte NumberOfDaysOffStandard { get; set; }
        public byte NumberOfDaysOffLastYear { get; set; }
        public string Describe { get; set; }
        public bool? Active { get; set; }

        public virtual TypePolicy TypePolicy { get; set; }
        public virtual ICollection<ApplySeniorityPolicy> ApplySeniorityPolicies { get; set; }
        public virtual ICollection<PersonnelApplyTimeOffPolicy> PersonnelApplyTimeOffPolicies { get; set; }
    }
}
