using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System.helpers
{
    public class HDateValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (Convert.ToDateTime(value) > DateTime.Now)
                {
                    return new ValidationResult("HDate shouldnt grater than current date");
                }
                else
                {
                    return ValidationResult.Success;
                }

            }
            else
            {
                return new ValidationResult("HDate is required");

            }
        }

    }
}
