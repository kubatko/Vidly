using System.Data.Entity;

namespace Vidly.Models
{
    public class VidlyDbContext : DbContext
    {
        public VidlyDbContext()
        {

        }
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<MembershipType> MemberShipTypes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
    }
}