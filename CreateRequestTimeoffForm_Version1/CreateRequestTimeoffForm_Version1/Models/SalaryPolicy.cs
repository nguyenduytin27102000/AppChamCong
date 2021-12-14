using System;
using System.Collections.Generic;

#nullable disable

namespace CreateRequestTimeoffForm_Version1.Models
{
    public partial class SalaryPolicy
    {
        public SalaryPolicy()
        {
            Personnel = new HashSet<Personnel>();
        }

        public string SalaryPolicyId { get; set; }
        public string SalaryPolicyName { get; set; }
        public string Describe { get; set; }
        public bool? States { get; set; }
        public bool? Del { get; set; }

        public virtual ICollection<Personnel> Personnel { get; set; }
    }
}
