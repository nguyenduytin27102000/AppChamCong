using System.ComponentModel.DataAnnotations;
using System.Linq;
using TimeKeeping.Models;

namespace TimeKeeping.CustomValidation.Personnels
{
    public class TheSamePersonnelID : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Use context to connect with database.
            var context = (TimeKeepingDBContext)validationContext.GetService(typeof(TimeKeepingDBContext));

            var listPersonnel = context.Personnel.ToList();

            string newPersonnelID = value.ToString();

            // If the same id, then display error!
            foreach (var personnel in listPersonnel)
            {
                if (newPersonnelID == personnel.PersonnelId)
                {
                    return new ValidationResult("This id is existing in data!");
                }
            }

            return ValidationResult.Success;
        }
    }
}
