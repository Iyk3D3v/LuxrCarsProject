using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxrCars.Domain.Models
{
   public  class ProductModel : Model
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        
        public decimal Price { get; set; }

        public string cModel { get; set; }

        public string Speed { get; set; }

        public int Year { get; set; }

        public string Power { get; set; }
        public int Quantity { get; set; }

        public virtual ICollection<ImageModel> Image { get; set; } = new HashSet<ImageModel>();

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //var errors = new List<ValidationResult>();
            if(Price < 0)
            {
               yield return new ValidationResult("Price Cannot be less than zero", new[] { nameof(Price) });
            }

            if(Quantity < 0)
            {
                yield return new ValidationResult("Quantity cannot be less than zero");
            }
            
        }

    }
}
