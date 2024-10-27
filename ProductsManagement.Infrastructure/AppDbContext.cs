using Microsoft.EntityFrameworkCore;
using ProductsManagement.Domain.Categories;
using ProductsManagement.Domain.Products;

namespace ProductsManagement.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .OwnsOne(p => p.Price);
        // modelBuilder.Entity<Category>()
        //     .OwnsOne(p => p.);
    }
}