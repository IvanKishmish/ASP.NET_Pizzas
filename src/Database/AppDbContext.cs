using AspNet1.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNet1.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    // public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Pizza> Pizzas => Set<Pizza>();
}