using Fintacharts.API.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fintacharts.API.Database;

public class FintachartsContext(
    DbContextOptions<FintachartsContext> options
    ) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
    
    public DbSet<AssetEntity> Assets { get; set; }
}
