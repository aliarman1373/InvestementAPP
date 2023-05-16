using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InvestmentAppProd.Core.Enums.Enum;

namespace InvestmentAppProd.Core.Models
{
    public class Investment
    {
        [Key]
        [Required]
        public Guid Id { get; set; } 
        [Required]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public InterestType InterestType { get; set; }

        public double InterestRate { get; set; }

        public double PrincipalAmount { get; set; }

        public double CurrentValue { get; set; } = 0;
    }
}
