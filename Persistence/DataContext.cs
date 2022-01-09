using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        /*protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }*/

        /*public DbSet<AppUser> Users { get; set; }*/
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<DetailEntry> DetailEntries { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Type> Types { get; set; }
    }
}