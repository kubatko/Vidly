namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class testDown : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "CustomerId", c => c.Int(nullable: false));
        }
    }
}
