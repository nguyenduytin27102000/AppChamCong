using System;
using System.Collections.Generic;

#nullable disable

namespace CreateRequestTimeoffForm_Version1.Models
{
    public partial class ApplySeniorityPolicy
    {
        public string TimeOffPolicyId { get; set; }
        public string SeniorityPolicyId { get; set; }

        public virtual SeniorityPolicy SeniorityPolicy { get; set; }
        public virtual TimeOffPolicy TimeOffPolicy { get; set; }
    }
}
