// importing namespaces
using Microsoft.EntityFrameworkCore;
using ProductsCategoryApi.Models;

// current namespace
namespace ProductsCategoryApi.Data
{
    public class AppDbContext: DbContext
    {
        // constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // DbSet properties
        public DbSet<Category> Categories { get; set; } // DbSet for the Category entity model
        public DbSet<Product> Products { get; set; } // DbSet for the Product entity Model

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relationship between Product and Category
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .Property(ci => ci.Price)
                .HasColumnType("decimal(18,2)"); // Ensure Price has the correct precision
        }
    }
}
