using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class BootstrapDbContext : DbContext
{
    
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=BootstrapDatabase;");
    }
}