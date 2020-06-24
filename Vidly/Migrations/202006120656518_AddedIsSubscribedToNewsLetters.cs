namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedIsSubscribedToNewsLetters : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewsLetters", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscribedToNewsLetters");
        }
    }
}
