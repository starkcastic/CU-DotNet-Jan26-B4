using Microsoft.EntityFrameworkCore;
using Vagabond.API.Models;

namespace Vagabond.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Destination> Destinations => Set<Destination>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Destination>(entity =>
        {
            entity.HasKey(d => d.Id);

            entity.Property(d => d.CityName)
                  .IsRequired();

            entity.Property(d => d.Country)
                  .IsRequired();

            entity.Property(d => d.Description)
                  .HasMaxLength(200);

            entity.Property(d => d.Rating)
                  .HasDefaultValue(3);
        });
    }
}