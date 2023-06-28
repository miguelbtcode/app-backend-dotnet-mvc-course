using CourseUdemyNetMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseUdemyNetMvc.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Category>? Category { get; set; }
    public DbSet<ApplicationType>? ApplicationType { get; set; }
    public DbSet<Product>? Product { get; set; }
}