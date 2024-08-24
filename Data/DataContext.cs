using BookzoneProjNituDaniel.Models;
using Microsoft.EntityFrameworkCore;

namespace BookzoneProjNituDaniel.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderProducts)
                .WithOne(e => e.Order);

            modelBuilder.Entity<Product>()
                .HasMany(e=>e.OrderProducts)
                .WithOne(e => e.Product);   

            modelBuilder.Entity<User>()
                .HasMany(e=>e.Orders)
                .WithOne(e=>e.User);    

        }
    }
}
