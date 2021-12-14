using System;
using System.Collections.Generic;

#nullable disable

namespace CreateRequestTimeoffForm_Version1.Models
{
    public partial class TimeOffApprover
    {
        public string PersonnelId { get; set; }
        public string FormTimeOffId { get; set; }
        public bool? Del { get; set; }

        public virtual FormTimeOff FormTimeOff { get; set; }
        public virtual Personnel Personnel { get; set; }
    }
}
