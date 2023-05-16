using InvestmentAppProd.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static InvestmentAppProd.Core.Enums.Enum;

namespace InvestmentAppProd.Core.Interfaces
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentRepository _repository;

        public InvestmentService(IInvestmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Investment>> GetAllAsync()
        {
            try
            {
                var investments = await _repository.GetAllAsync();
                foreach (var investment in investments)
                {
                    investment.CurrentValue = CalculateInvestmentInterest(investment);
                }
                return investments;
            }
            catch (Exception)
            {
                //TODO: log exception
                throw;
            }
        }
        public async Task<Investment> GetByIdAsync(Guid id)
        {
            try
            {
                var investment = await _repository.GetAsync(x => x.Id == id);
                investment.CurrentValue = CalculateInvestmentInterest(investment);
                return investment;

            }
            catch (Exception)
            {
                //TODO: log exception
                throw;
            }
        }

        public async Task CreateAsync(Investment entity)
        {
            try
            {
                entity.Id = Guid.NewGuid();
                await _repository.CreateAsync(entity);
            }
            catch (Exception)
            {
                //TODO: log exception
                throw;
            }
        }

        public async Task<Investment> DeleteAsync(Guid id)
        {
            try
            {
                var investment = GetByIdAsync(id).Result;
                if (investment != null)
                {
                    await _repository.DeleteAsync(investment);
                }
                return investment;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<Investment> UpdateAsync(Investment entity)
        {
            try
            {
                var investment = GetByIdAsync(entity.Id).Result;
                if (investment != null)
                {
                    await _repository.UpdateAsync(investment);
                }
                return investment;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public double CalculateInvestmentInterest(Investment investment, int numberOfCompoundingPeriod = 12)
        {
            double rate = investment.InterestRate / 100;
            double time = CalculateTime(investment.StartDate);
            if (investment.InterestType == InterestType.Simple)
                return Math.Round(investment.PrincipalAmount * (1 + rate * time), 2);
            else
                return Math.Round(investment.PrincipalAmount * Math.Pow(1 + rate / numberOfCompoundingPeriod, numberOfCompoundingPeriod * time), 2);
        }

        public double CalculateTime(DateTime startDate)
        {
            var monthsDiff = 12 * (startDate.Year - DateTime.Now.Year) + startDate.Month - DateTime.Now.Month;
            return Math.Abs(monthsDiff) / 12;
        }


    }
}
