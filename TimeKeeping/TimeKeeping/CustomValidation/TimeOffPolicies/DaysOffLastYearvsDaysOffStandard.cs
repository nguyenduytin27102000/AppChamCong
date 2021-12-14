using System.ComponentModel.DataAnnotations;

namespace TimeKeeping.CustomValidation.TimeOffPolicies
{
    public class DaysOffLastYearvsDaysOffStandard : ValidationAttribute
    {
        private readonly string _numberOfDaysOffStandard;

        public DaysOffLastYearvsDaysOffStandard(string numberOfDaysOffStandard)
        {
            _numberOfDaysOffStandard = numberOfDaysOffStandard;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_numberOfDaysOffStandard.ToString());

            byte numberOfDaysOffStandard = (byte)property.GetValue(validationContext.ObjectInstance, null);
            byte numberOfDaysOffLastYear = (byte)value;

            if (numberOfDaysOffLastYear > numberOfDaysOffStandard)
            {
                return new ValidationResult("Number of days off last year is illegal!");
            }

            return ValidationResult.Success;
        }
    }
}
