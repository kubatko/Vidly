namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SomeChangesInModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "IsSubscribedToNewsLetter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
        }
    }
}
