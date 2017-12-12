namespace LuxrCars.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SortedDataTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.OrderItems", "Quantity", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderItems", "ProductID");
            AddForeignKey("dbo.OrderItems", "ProductID", "dbo.Products", "ProductID", cascadeDelete: true);
            DropColumn("dbo.OrderItems", "UserID");
            DropColumn("dbo.OrderItems", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "MyProperty", c => c.Int(nullable: false));
            AddColumn("dbo.OrderItems", "UserID", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderItems", "ProductID", "dbo.Products");
            DropIndex("dbo.OrderItems", new[] { "ProductID" });
            DropColumn("dbo.OrderItems", "Quantity");
            DropColumn("dbo.Products", "Quantity");
        }
    }
}
