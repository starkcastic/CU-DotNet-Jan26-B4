using Microsoft.EntityFrameworkCore;
using WealthTrack.Models;
public class PortfolioContext : DbContext
{
    public PortfolioContext(DbContextOptions<PortfolioContext> options)
        : base(options)
    {
    }

    public DbSet<Investment> Investments { get; set; }
}