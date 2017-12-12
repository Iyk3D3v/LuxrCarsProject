using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxrCars.Infrastructure.Data
{
    public class Customer
    {
        [Key,ForeignKey("User")]
        public int UserID { get; set; }
        public string Address { get; set; }

        public string phoneNumber { get; set; }

        public virtual User User { get; set; }
    }
}
