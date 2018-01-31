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

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string Image { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<Order> Order { get; set; } = new HashSet<Order>();

        public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();


    }
}
 