using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcTest.Models
{
    public class ValidateBirhdate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Custumer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.PayAsyouGo || customer.MembershipTypeId == MembershipType.unknown)
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("birthdate Cant not be empty.");
            var age = DateTime.Today.Year - customer.BirthDate.Year;

            return (age >= 18) ? ValidationResult.Success :
             new ValidationResult("Members should be at least 18 years old");

        }
    }
}