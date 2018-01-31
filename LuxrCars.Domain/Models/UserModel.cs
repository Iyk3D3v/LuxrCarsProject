using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxrCars.Domain.Models
{
    public class UserModel : Model
    {
        public int UserID { get; set; }

       

        public string Email { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string fullname { get; set; } 
        public string Image { get; set; }

        public string[] Role { get; set; }
    }
}
