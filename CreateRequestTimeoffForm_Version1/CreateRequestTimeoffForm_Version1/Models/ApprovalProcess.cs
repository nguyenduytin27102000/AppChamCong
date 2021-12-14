using System;
using System.Collections.Generic;

#nullable disable

namespace CreateRequestTimeoffForm_Version1.Models
{
    public partial class ApprovalProcess
    {
        public ApprovalProcess()
        {
            FormTimeOffs = new HashSet<FormTimeOff>();
        }

        public string ApprovalProcessId { get; set; }
        public string ApprovalProcessName { get; set; }
        public bool? Del { get; set; }

        public virtual ICollection<FormTimeOff> FormTimeOffs { get; set; }
    }
}
