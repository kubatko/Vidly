namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class testUp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "CustomerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "CustomerId");
        }
    }
}
