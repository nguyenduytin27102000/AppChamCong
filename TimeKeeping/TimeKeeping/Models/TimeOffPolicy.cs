using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TimeKeeping.CustomValidation.TimeOffPolicies;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class TimeOffPolicy
    {
        public TimeOffPolicy()
        {
            ApplySeniorityPolicies = new HashSet<ApplySeniorityPolicy>();
            PersonnelApplyTimeOffPolicies = new HashSet<PersonnelApplyTimeOffPolicy>();
        }

        [Display(Name = "Timeoff policy ID")]
        [Required(ErrorMessage = "Please enter timeoff policy ID!")]
        [StringLength(10, ErrorMessage = "Can enter 10 charaters")]
        public string TimeOffPolicyId { get; set; }

        [Display(Name = "Timeoff Policy Name")]
        [Required(ErrorMessage = "Please enter timeoff policy name!")]
        public string TimeOffPolicyName { get; set; }

        [Display(Name = "Type Policy")]
        public string TypePolicyId { get; set; }

        [Display(Name = "Number of days off standard")]
        [Required(ErrorMessage = "Please enter number of days off standard!")]
        public byte NumberOfDaysOffStandard { get; set; }

        [Display(Name = "Number of days off last year")]
        [Required(ErrorMessage = "Please enter number of days off last year!")]
        [DaysOffLastYearvsDaysOffStandard("NumberOfDaysOffStandard")]
        public byte NumberOfDaysOffLastYear { get; set; }

        [Required(ErrorMessage = "Please enter discription!")]
        public string Describe { get; set; }

        public bool? Del { get; set; }

        [Display(Name = "Type Policy")]
        public virtual TypePolicy TypePolicy { get; set; }
        public virtual ICollection<ApplySeniorityPolicy> ApplySeniorityPolicies { get; set; }
        public virtual ICollection<PersonnelApplyTimeOffPolicy> PersonnelApplyTimeOffPolicies { get; set; }
    }
}