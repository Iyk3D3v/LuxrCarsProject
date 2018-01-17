using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace LuxrCars.Infrastructure
{
    public class DatabaseMigrator
    {
        public static void UpdateDatabase()
        {
            try
            {
                var migrator = new DbMigrator(new DbMigrationsConfiguration());
                migrator.Update();
            }

            catch(Exception e)
            {

            }
           


        }
    }
}