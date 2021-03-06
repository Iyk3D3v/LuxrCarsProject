﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxrCars.Infrastructure.Data
{
    public class DataEntities: DbContext 
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderItem> Orderitems { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
    }
}
