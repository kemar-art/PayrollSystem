using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.Services
{
    internal interface INationalInsuranceSchemeService
    {
        decimal NISConrtibution(decimal totalAmount);
    }
}
