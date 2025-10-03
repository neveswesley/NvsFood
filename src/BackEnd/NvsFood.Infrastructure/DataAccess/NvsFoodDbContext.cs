using Microsoft.EntityFrameworkCore;
using NvsFood.Domain.Entities;

namespace NvsFood.Infrastructure.DataAccess;

public class NvsFoodDbContext : DbContext
{
    public NvsFoodDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NvsFoodDbContext).Assembly);
    }
}