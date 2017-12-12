namespace LuxrCars.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LuxrCars.Infrastructure.Data.DataEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LuxrCars.Infrastructure.Data.DataEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Products.AddOrUpdate(p => p.Name, new Data.Product
            {
                Name = "Nissan GTR",
                Price = 150000,
                Quantity = 100,
                cModel = "2017",
                Power = "700BHP",
                Year = 2017,
                Speed = "0-60 in 2.8 seconds"

            },
            new Data.Product
            {
                Name = "Lamborhgini Huracan",
                Price = 250000,
                Quantity = 32,
                cModel = "2017",
                Power = "1200BHP",
                Year = 2017,
                Speed = "0-60 in 2 seconds"

            });
        }
    }
}