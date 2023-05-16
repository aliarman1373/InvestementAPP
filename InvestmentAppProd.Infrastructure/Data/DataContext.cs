using InvestmentAppProd.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestmentAppProd.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Investment> Investments { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

    }
}
