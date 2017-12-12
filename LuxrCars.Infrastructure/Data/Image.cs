using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxrCars.Infrastructure.Data
{
    public class Image
    {
        public int ImageID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }

        public string Url { get; set; }

        public virtual Product Product { get; set; }


    }
}
