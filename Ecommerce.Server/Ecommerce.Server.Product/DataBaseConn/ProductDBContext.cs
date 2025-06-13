using Ecommerce.Server.Product.Model;
using Microsoft.EntityFrameworkCore;
namespace Ecommerce.Server.Product.DataBaseConn
{
    public class ProductDBContext: DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options)
            : base(options)
        {
        }
        // Define DbSet properties for your entities here
        // public DbSet<Category> Categories { get; set; }
        // public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure entity relationships and properties here

            modelBuilder.Entity<Category>().HasData(
                
                
                
                
                new Category { Id = 1, Name = "Electronics", Description = "Devices and gadgets" },
                new Category { Id = 2, Name = "Clothing", Description = "Apparel and accessories" },
                new Category { Id = 3, Name = "Books", Description = "Literature and educational materials" }
            );


            modelBuilder.Entity<ProductDetail>().HasData(
                new ProductDetail { Id = Guid.NewGuid(), Name = "Smartphone", Description = "Latest model smartphone", Price = 699.99m, ImageUrl = "https://example.com/smartphone.jpg", StockQuantity = 50, CategoryId = 1, DiscountPercentage = 10 },
                new ProductDetail { Id = Guid.NewGuid(), Name = "T-Shirt", Description = "Cotton t-shirt", Price = 19.99m, ImageUrl = "https://example.com/tshirt.jpg", StockQuantity = 100, CategoryId = 2, DiscountPercentage = 5 },
                new ProductDetail { Id = Guid.NewGuid(), Name = "Programming Book", Description = "Learn C# programming", Price = 29.99m, ImageUrl = "https://example.com/book.jpg", StockQuantity = 200, CategoryId = 3, DiscountPercentage = 15 }
            );

        }


        public DbSet<Category> Categories { get; set; } 
        public DbSet<ProductDetail> Products { get; set; }
        
    }   
    
}
