using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestKSApp_BE_BL.Interfaces;

namespace TechnicalTestKSApp_BE_BL.Models.Validator
{
    public class IsAdultPersonAttribute : ValidationAttribute
    {
        public IsAdultPersonAttribute() { }

        public string GetErrorMessage() => "Only persons being greater than 18 years can be registered.";

        protected override ValidationResult? IsValid(
            object? value, ValidationContext validationContext)
        {
            //var person = (IPerson)validationContext.ObjectInstance;
            var inputValue = (DateTime)value!;

            DateTime adultDate = inputValue.AddYears(18);

            if (adultDate > DateTime.Now)
                return new ValidationResult(GetErrorMessage());

            return ValidationResult.Success;
        }
    }
}
