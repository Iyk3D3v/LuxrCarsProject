using LuxrCars.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuxrCars.Models
{
    public class RegisterViewModel : Model
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Text)]
        public string firstName { get; set; }

        public string lastName { get; set; }
        [DataType(DataType.Password),MinLength(5,ErrorMessage ="Password should be more than 5 characters")]
        public string passWord { get; set; }
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (passWord != confirmPassword)
            {
                yield return new ValidationResult("Passwords do not match", new[] { nameof(passWord), nameof(confirmPassword) });
            }


        }
    }
}