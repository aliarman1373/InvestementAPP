using AutoMapper;
using InvestmentAppProd.Core.Models;
using InvestmentAppProd.Models;

namespace InvestmentAppProd.Mappers
{
    public class InvestmentProfile:Profile
    {
        public InvestmentProfile()
        {
            CreateMap<Investment, AddInvestmentModel>().ReverseMap();
        }
    }
}
