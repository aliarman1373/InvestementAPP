using InvestmentAppProd.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvestmentAppProd.Core.Interfaces
{
    public interface IInvestmentService
    {
        double CalculateInvestmentInterest(Investment investment, int numberOfCompoundingPeriod = 12);

        double CalculateTime(DateTime startDate);
        Task CreateAsync(Investment entity);
        Task<Investment> DeleteAsync(Guid id);
        Task<IEnumerable<Investment>> GetAllAsync();
        Task<Investment> GetByIdAsync(Guid id);
        Task<Investment> UpdateAsync(Investment entity);
    }
}