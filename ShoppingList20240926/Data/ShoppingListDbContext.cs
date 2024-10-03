using Microsoft.EntityFrameworkCore;
using ShoppingList20240926.Data.Models;

namespace ShoppingList20240926.Data
{
    public class ShoppingListDbContext : DbContext
    {
        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<ProductNote> ProductNotes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(p => p.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Cheese"
                },
                new Product
                {
                    Id = 2,
                    Name = "Milk"
                },
                new Product
                {
                    Id = 3,
                    Name = "Pizza"
                },
                new Product
                {
                    Id = 4,
                    Name = "Water"
                }));

            base.OnModelCreating(modelBuilder);
        }
    }
}
