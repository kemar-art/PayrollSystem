using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.Services
{
    internal class EducationTaxService : IEducationTaxService, INationalInsuranceSchemeService
    {
        private decimal nisRate;
        private decimal nis;
        private decimal eduRate;
        private decimal edu;
        public decimal EducationTaxContibution(decimal totalAmount)
        {
            eduRate = 0.0225m;
            edu = ((totalAmount - nis) * eduRate);
            return edu;
        }

        
        public decimal NISConrtibution(decimal totalAmount)
        {
            nisRate = 0.03m;
            nis = ((totalAmount) * nisRate) / 100;
            return nis;
        }
    }
}
