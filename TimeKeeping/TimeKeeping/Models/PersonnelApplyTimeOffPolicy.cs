using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class PersonnelApplyTimeOffPolicy
    {      
        public string PersonnelId { get; set; }
        public string TimeOffPolicyId { get; set; }
        [DisplayName("Date")]
        public DateTime EffectiveDate { get; set; }
        [DisplayName("Days of Last year ")]
        public byte NumberOfDaysOffLastYear { get; set; }
        [DisplayName("Days of Standard ")]
        public byte NumberOfDaysOffStandard { get; set; }
        [DisplayName("Days of seniority ")]
        public byte NumberOfDaysOffSeniority { get; set; }
        [DisplayName("Days of Offset ")]
        public byte NumberOfDaysOffOffset { get; set; }
        public string Note { get; set; }
        public bool? Active { get; set; }
        [DisplayName("Employee")]
        public virtual Personnel Personnel { get; set; }
        [DisplayName("Timeoff Policy")]
        public virtual TimeOffPolicy TimeOffPolicy { get; set; }
    }
}
