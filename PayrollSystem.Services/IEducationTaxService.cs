using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.Services
{
    public interface IEducationTaxService
    {
        decimal EducationTaxContibution(decimal totalAmount);
    }
}
