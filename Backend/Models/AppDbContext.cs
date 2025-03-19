using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public class AppDbContext : DbContext
{

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductVariant> ProductVariants { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }


}
