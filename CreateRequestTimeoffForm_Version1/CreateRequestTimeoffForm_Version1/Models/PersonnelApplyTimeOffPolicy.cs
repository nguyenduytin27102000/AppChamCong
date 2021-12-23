using System;
using System.Collections.Generic;

#nullable disable

namespace CreateRequestTimeoffForm_Version1.Models
{
    public partial class PersonnelApplyTimeOffPolicy
    {
        public string PersonnelId { get; set; }
        public string TimeOffPolicyId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public byte NumberOfDaysOffLastYear { get; set; }
        public byte NumberOfDaysOffStandard { get; set; }
        public byte NumberOfDaysOffSeniority { get; set; }
        public byte NumberOfDaysOffOffset { get; set; }
        public string Note { get; set; }
        public bool? Del { get; set; }

        public virtual Personnel Personnel { get; set; }
        public virtual TimeOffPolicy TimeOffPolicy { get; set; }
    }
}
