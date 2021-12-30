using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class PersonnelApplyTimeOffPolicy
    {
        public string PersonnelId { get; set; }
        public string TimeOffPolicyId { get; set; }
        [DisplayName("Effective Date")]
        public DateTime EffectiveDate { get; set; }

        [DisplayName("Last Year")]
        public byte NumberOfDaysOffLastYear { get; set; }

        [DisplayName("Standard")]
        public byte NumberOfDaysOffStandard { get; set; }
        [DisplayName("Seniority")]
        public byte NumberOfDaysOffSeniority { get; set; }
        [DisplayName("Offset")]
        public byte NumberOfDaysOffOffset { get; set; }
        
        public string Note { get; set; }
        public bool? Active { get; set; }
        [DisplayName("Person")]
        public virtual Personnel Personnel { get; set; }
        [DisplayName("TimeOff Policy")]
        public virtual TimeOffPolicy TimeOffPolicy { get; set; }
    }
}
