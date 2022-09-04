using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.Services.Implementations
{
    public class iTaxService : IiTaxService
    {
        private decimal itax;
        private decimal itaxRate;
        //private decimal itaxRate2;
        //private decimal emolument;
        //private decimal emolument2;
        public decimal TaxAmount(decimal totalAmount)
        {
            if (totalAmount <= 1500096)
            {
                //Tax free rate
                itaxRate = .0m;
                itax = totalAmount * itaxRate;
            }
            else if (totalAmount > 1500096 && totalAmount <= 6000000 )
            {
                //Basic tax rate
                itaxRate = 0.25m;
                //Income tax ( Taxable emoluments up to JMD 6 million per annum less the annual tax-free threshold at 25%)
                //itax = ((totalAmount - 1500096) * itaxRate);
                itax = (1500096 * .0m) + ((totalAmount - 1500096) * itaxRate);
            }
            else if (totalAmount > 6000000)
            {
                //Higher tax rate
                itaxRate = 0.30m;
                //Income tax ( Taxable emoluments in excess of JMD 6 million per annum 30% )
                itax = (1500096 * .0m) + ((1500096 - 1042) * .25m) + ((totalAmount - 1500096) * itaxRate);
            }
            return itax;
        }
    }
}

