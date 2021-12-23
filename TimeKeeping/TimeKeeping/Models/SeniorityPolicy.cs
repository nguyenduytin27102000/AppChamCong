using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class SeniorityPolicy
    {
        public SeniorityPolicy()
        {
            ApplySeniorityPolicies = new HashSet<ApplySeniorityPolicy>();
        }

        public string SeniorityPolicyId { get; set; }
        public int SeniorityMonth { get; set; }
        public byte PolicyDay { get; set; }
        public bool? Del { get; set; }

        public virtual ICollection<ApplySeniorityPolicy> ApplySeniorityPolicies { get; set; }
    }
}
