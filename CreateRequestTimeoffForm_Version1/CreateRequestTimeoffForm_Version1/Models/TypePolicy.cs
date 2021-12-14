using System;
using System.Collections.Generic;

#nullable disable

namespace CreateRequestTimeoffForm_Version1.Models
{
    public partial class TypePolicy
    {
        public TypePolicy()
        {
            TimeOffPolicies = new HashSet<TimeOffPolicy>();
        }

        public string TypePolicyId { get; set; }
        public string TypePolicyName { get; set; }
        public bool? Del { get; set; }

        public virtual ICollection<TimeOffPolicy> TimeOffPolicies { get; set; }
    }
}
