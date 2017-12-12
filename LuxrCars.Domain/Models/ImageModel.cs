using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxrCars.Domain.Models
{
    public class ImageModel
    {
        public int ImageID { get; set; }

        [ForeignKey("ProductModel")]
        public int ProductID { get; set; }

        public Uri Url { get; set; }

        public virtual ProductModel Product { get; set; }
    }
}
