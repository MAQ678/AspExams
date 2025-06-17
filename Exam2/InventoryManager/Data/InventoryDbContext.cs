using InventoryManager.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {

        }

        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductEntity>()
                .HasData(
                new ProductEntity
                {
                    Id = 1,
                    Name = "MacBook Pro",
                    Category = Category.Electronics,
                    Price = 1299.99,
                    Quantity = 15,
                },
                new ProductEntity
                {
                    Id = 2,
                    Name = "Organic Honey",
                    Category = Category.Food,
                    Price = 12.99,
                    Quantity = 5,
                }, new ProductEntity
                {
                    Id = 3,
                    Name = "Nike Air Max",
                    Category = Category.Clothing,
                    Price = 129.99,
                    Quantity = 0,
                });
        }
    }
}
