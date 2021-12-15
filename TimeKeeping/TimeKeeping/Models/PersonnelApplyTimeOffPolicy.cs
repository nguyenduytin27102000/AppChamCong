using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class PersonnelApplyTimeOffPolicy
    {
        [DisplayName("Personnel Id")]
        public string PersonnelId { get; set; }

        [DisplayName("TimeOffPolicy Id")]
        public string TimeOffPolicyId { get; set; }

        [DisplayName("Effective Date")]
        public DateTime EffectiveDate { get; set; }

        [DisplayName("Number Of DaysOff Last Year")]
        public byte NumberOfDaysOffLastYear { get; set; }


        [DisplayName("Number Of DaysOff Standard")]
        public byte NumberOfDaysOffStandard { get; set; }

        [DisplayName("Number Of DaysOff Seniority")]
        public byte NumberOfDaysOffSeniority { get; set; }

        [DisplayName("Number O fDaysOff Offset")]
        public byte NumberOfDaysOffOffset { get; set; }

        [DisplayName("Note")]
        public string Note { get; set; }

        public bool? Del { get; set; }

        [DisplayName("Personnal")]
        public virtual Personnel Personnel { get; set; }
        [DisplayName("TimeOff Policy")]
        public virtual TimeOffPolicy TimeOffPolicy { get; set; }
    }
}