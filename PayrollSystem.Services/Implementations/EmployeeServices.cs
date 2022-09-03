using PayrollSystem.Entity;
using PayrollSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.Services.Implementations
{
    public class EmployeeServices : IEmloyeeService
    {
        private readonly ApplicationDbContext context;

        public EmployeeServices(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(Employee newEmployee)
        {
            await context.Employees.AddAsync(newEmployee);
            await context.SaveChangesAsync();
        }

        public Employee GetById(int employeeId) => context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();

        public async Task DeleteAsync(int employeeId)
        {
            var employee = GetById(employeeId);
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
        }

        public IEnumerable<Employee> GetAll() => context.Employees;

        public async Task UpdateAsync(Employee employee)
        {
            context.Employees.Update(employee);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id)
        {
            //var employee = context.Employees.Where(e => e.Id == id).FirstOrDefault();
            var employee = GetById(id);
            context.Employees.Update(employee);
            await context.SaveChangesAsync();
        }

        public decimal LoanRepaymentAmount(int id, decimal totalAmount)
        {
            throw new NotImplementedException();
        }

        public decimal UnionFees(int id)
        {
            throw new NotImplementedException();
        }
    }
}
