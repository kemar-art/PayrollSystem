using PayrollSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.Services
{
    public interface IEmloyeeService
    {
        Task CreateAsync(Employee newEmployee);
        Employee GetById(int employeeId);
        Task UpdateAsync(Employee employee);
        Task UpdateAsync(int id);
        Task DeleteAsync(int employeeId);
        decimal UnionFees(int id);
        decimal LoanRepaymentAmount(int id, decimal totalAmount);
        IEnumerable<Employee> GetAll();
    }
}
