using Microsoft.EntityFrameworkCore;
using LoanMang.Models;

namespace LoanMang.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Loan> Loans { get; set; }
    }
}