using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class ElevDbContext : DbContext
{
    public DbSet<Elev> Elever { get; set; }
    public DbSet<Kurs> Kurser { get; set; }
    public DbSet<Skola> Skolor { get; set; }

    public ElevDbContext(DbContextOptions options) : base(options)
    {
        
    }
}