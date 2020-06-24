namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateMovieGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Comedy')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Drama')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Sci-Fi')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Horror')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Mysterious')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Romantic')");
        }
        
        public override void Down()
        {
        }
    }
}
