using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxrCars.Infrastructure.Data
{
    public class UserRole
    {
        public int UserRoleId { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }

        public virtual User user
        {
            get;
            set;
        }

            public virtual Role role { get; set; }
        }
    }

