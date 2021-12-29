using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        
        [Display(Name = "Timeoff policy name")]
        public string TimeOffPolicyName { get; set; }

        [Display(Name = "Policy type")]
        public string TypePolicyId { get; set; }

        [Display(Name = "Number of dayoff standard")]
        public byte NumberOfDaysOffStandard { get; set; }

        [Display(Name = "Number of dayoff last year")]
        public byte NumberOfDaysOffLastYear { get; set; }
        public string Describe { get; set; }
        public bool? Active { get; set; }

        [Display(Name = "Policy type")]
        public virtual TypePolicy TypePolicy { get; set; }
        public virtual ICollection<ApplySeniorityPolicy> ApplySeniorityPolicies { get; set; }
        public virtual ICollection<PersonnelApplyTimeOffPolicy> PersonnelApplyTimeOffPolicies { get; set; }
    }
}
