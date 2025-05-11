using Microsoft.EntityFrameworkCore;
using Shop_API.Entities.Categories;
using Shop_API.Entities.Products;
using Shop_API.Entities.SalesUnits;
using Shop_API.Entities.Subcategories;
using Shop_API.Entities.Thicknesses;
using Shop_API.Entities.Users;

namespace Shop_API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    
    public DbSet<AppUser> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<SalesUnit> SalesUnits { get; set; }
    public DbSet<Thickness> Thicknesses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Subcategory> SubCategories { get; set; }
    
    // Configuring relationships and model setup
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Thicknesses)
            .WithMany(t => t.Products)
            .UsingEntity(j => j.ToTable("ProductThickness"));
    }
}