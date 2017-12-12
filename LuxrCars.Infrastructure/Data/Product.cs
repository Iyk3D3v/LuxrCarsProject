using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxrCars.Infrastructure.Data
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string cModel { get; set; }

        public string Speed { get; set; }

        public int Quantity { get; set; }


        public int Year { get; set; }

        public string Power { get; set; }

        public virtual ICollection<Image> Image { get; set; } = new HashSet<Image>();

        public virtual ICollection<OrderItem> OrderItem { get; set; } = new HashSet<OrderItem>();






    }
}
