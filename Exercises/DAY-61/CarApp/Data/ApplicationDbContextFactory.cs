using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CarApp.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=localhost,1433;Database=CarDb;User Id=sa;Password=niSHANt@26;TrustServerCertificate=True;"
            );

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}