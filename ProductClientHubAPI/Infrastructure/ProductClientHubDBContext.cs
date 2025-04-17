using Microsoft.EntityFrameworkCore;
using ProductClientHubAPI.Entities;

namespace ProductClientHubAPI.Infrastructure;

public class ProductClientHubDBContext:DbContext
{
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<Product> Products { get; set; }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=products.db");
    }
    
    
}