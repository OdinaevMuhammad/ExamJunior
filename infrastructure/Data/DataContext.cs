using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext>options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    } 

    public DbSet<Order> Orders { get; set;}
    public DbSet<Product> Products { get; set;}
    
    
}