using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace Vidly.Models
{
    public class NumberInStockEqualZeroValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;


            return (movie.NumberInStock > 0)
                ? ValidationResult.Success
                : new ValidationResult("The field Number in Stock must be between 1 and 20");
        }
    }
}