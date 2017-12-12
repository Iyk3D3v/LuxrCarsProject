using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxrCars.Infrastructure.Data
{
    public class Order
    {
        public int OrderID { get; set; }
      
        [ForeignKey("User")]
        public int UserID { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DeliveryDate { get; set; }

        public virtual ICollection<OrderItem> OrderItem { get; set; } = new HashSet<OrderItem>();

        public virtual User User { get; set; }

        public virtual ICollection<Payment> Payment { get; set; } = new HashSet<Payment>();




    }
}
