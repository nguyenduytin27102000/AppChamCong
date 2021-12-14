using System.ComponentModel.DataAnnotations;
using System.Linq;
using TimeKeeping.Models;

namespace TimeKeeping.CustomValidation.TimeOffPolicies
{
    public class TheSameTimeOffPolicyID : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (TimeKeepingDBContext)validationContext.GetService(typeof(TimeKeepingDBContext));
            var listtimeOffPolicies = context.TimeOffPolicies.ToList();

            string newPolicyID = value.ToString();

            foreach (var oldTimeOffPolicy in listtimeOffPolicies)
            {
                if (newPolicyID == oldTimeOffPolicy.TimeOffPolicyId)
                {
                    return new ValidationResult("This id is existing in data!");
                }
            }

            return ValidationResult.Success;
        }
    }
}
