using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HamedaniProject.Models
{
    public class Min18YearsValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (CustomerTable)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }
            if(customer.Birthdate == null)
            {
                return new ValidationResult("Please add a Date of birth");

            }

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return age >= 18 ? ValidationResult.Success : new ValidationResult("Age must be above 18");
           
        }
    }
}