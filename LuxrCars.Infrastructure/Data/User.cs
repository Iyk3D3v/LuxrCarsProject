using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxrCars.Infrastructure.Data
{
    public class User
    {
        public int UserID { get; set; }

        public string password { get; set; }

        public string Email { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string Image { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<Order> Order { get; set; } = new HashSet<Order>();
    }
}
