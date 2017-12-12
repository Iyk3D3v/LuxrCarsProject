using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LuxrCars.Domain.Models
{
    public abstract class Model : IValidatableObject
    {
        public void Validate()
        {
           Validator.ValidateObject(this, new ValidationContext(this, null, null));
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }
    }
}
