namespace LuxrCars.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPayment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        Status = c.String(),
                        Reference = c.String(),
                        ReceiptNo = c.String(),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "OrderID", "dbo.Orders");
            DropIndex("dbo.Payments", new[] { "OrderID" });
            DropTable("dbo.Payments");
        }
    }
}
