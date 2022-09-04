using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.Services.Implementations
{
    public class NationalInsuranceSchemeService : INationalInsuranceSchemeService
    {
        private decimal nisRate;
        private decimal nis;
        public decimal NISConrtibution(decimal totalAmount)
        {
            nisRate = 0.03m;
            nis = ((totalAmount) * nisRate) / 100;
            return nis;
        }
    }
}
