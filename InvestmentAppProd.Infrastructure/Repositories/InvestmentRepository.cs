using InvestmentAppProd.Core.Interfaces;
using InvestmentAppProd.Core.Models;
using InvestmentAppProd.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentAppProd.Infrastructure.Repositories
{
    public class InvestmentRepository: Repository<Investment>, IInvestmentRepository
    {
        private readonly DataContext db;

        public InvestmentRepository(DataContext db) : base(db)
        {
            this.db = db;
        }
    }
}
