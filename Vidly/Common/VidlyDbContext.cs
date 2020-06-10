using System.Data.Entity;

namespace Vidly.Models
{
    public class VidlyDbContext : DbContext
    {
        public VidlyDbContext()
        {

        }
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Order> Orders { get; set; }
     

    }
}