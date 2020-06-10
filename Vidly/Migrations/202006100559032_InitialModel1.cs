namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            CreateTable(
                "dbo.CustomerOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Customer_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Order_Id);
            
            DropColumn("dbo.Orders", "Customer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Customer_Id", c => c.Int());
            DropForeignKey("dbo.CustomerOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.CustomerOrders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.CustomerOrders", new[] { "Order_Id" });
            DropIndex("dbo.CustomerOrders", new[] { "Customer_Id" });
            DropTable("dbo.CustomerOrders");
            CreateIndex("dbo.Orders", "Customer_Id");
            AddForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
