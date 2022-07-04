using AndelaTest.Models;
using Microsoft.EntityFrameworkCore;

namespace AndelaTest.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

         public DbSet<Product> Products => Set<Product>();
        public DbSet<Merchant> Merchants => Set<Merchant>();
    }

       
}