using InvestmentAppProd.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentAppProd.Infrastructure.Data
{
    public class InvestmentDBContext : DbContext
    {
        public DbSet<Investment> Investments { get; set; }

        public InvestmentDBContext(DbContextOptions<InvestmentDBContext> options) : base(options)
        {
        }

    }
}
