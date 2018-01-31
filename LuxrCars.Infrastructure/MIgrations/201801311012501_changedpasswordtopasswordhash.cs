namespace LuxrCars.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedpasswordtopasswordhash : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PasswordHash", c => c.String());
            DropColumn("dbo.Users", "password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "password", c => c.String());
            DropColumn("dbo.Users", "PasswordHash");
        }
    }
}
