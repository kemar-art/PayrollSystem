using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.Services.Implementations
{
    public class NationalhousingtrustService : INationalhousingtrustService
    {
        private decimal nhtRate;
        private decimal nht;
        public decimal NationalhousingtrustContribution(decimal totalAmount)
        {
            nhtRate = 0.02m;
            nht = totalAmount * nhtRate;
            return nht;
        }
    }
}
