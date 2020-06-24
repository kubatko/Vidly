namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialModel2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerOrders", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.CustomerOrders", "Order_Id", "dbo.Orders");
            DropIndex("dbo.CustomerOrders", new[] { "Customer_Id" });
            DropIndex("dbo.CustomerOrders", new[] { "Order_Id" });
            DropTable("dbo.CustomerOrders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomerOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Customer_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.CustomerOrders", "Order_Id");
            CreateIndex("dbo.CustomerOrders", "Customer_Id");
            AddForeignKey("dbo.CustomerOrders", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.CustomerOrders", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
