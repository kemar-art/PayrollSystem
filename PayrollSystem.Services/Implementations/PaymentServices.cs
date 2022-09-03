using Microsoft.AspNetCore.Mvc.Rendering;
using PayrollSystem.Entity;
using PayrollSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.Services.Implementations
{
    public class PaymentServices : IPaymentService
    {
        private readonly ApplicationDbContext context;
        private decimal contractualEarnings;
        private decimal totalNetPay;
        private decimal totalOvertimeEarning;
        private object overtimeHours;
        private object overtimeRate;
        private decimal totalDeduction;
        private decimal totalEranings;
        private decimal holidyEarning;
        private decimal holidayHours;

        public PaymentServices(ApplicationDbContext context)
        {
            this.context = context;
        }
        public decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate)
        {
            if (hoursWorked < contractualHours)
            {
                contractualEarnings = hoursWorked * hourlyRate;
            }
            else
            {
                contractualEarnings = contractualHours * hourlyRate;
            }
            return contractualEarnings;
        }

        public async Task CreateAsync(PaymentRecord paymentRecord)
        {
            await context.PaymentRecords.AddAsync(paymentRecord);
            await context.SaveChangesAsync();
        }

        public IEnumerable<PaymentRecord> GetAll()
        {
            context.PaymentRecords.OrderBy(p => p.EmployeeId);
            return context.PaymentRecords;
        }

        public IEnumerable<SelectListItem> GetAllTaxYear()
        {
            var allTaxYear = context.TaxYears.Select(taxYaars => new SelectListItem
            {
                Text = taxYaars.YearOfTax,
                Value = taxYaars.Id.ToString()
            });

            return allTaxYear;
        }

        public PaymentRecord GetById(int id) => context.PaymentRecords.Where(pay => pay.Id == id).FirstOrDefault();


        public decimal HolidayEarning(decimal holidayRate, decimal holidayHours)
        {
            holidyEarning = holidayRate * holidayHours;
            return holidyEarning;
        }

        public decimal HolidayHours(decimal hoursWorked, decimal contractualHours)
        {
            if(hoursWorked <= contractualHours)
            {
                holidayHours = 0.00m;
            }
            else if (hoursWorked > contractualHours)
            {
                holidayHours = hoursWorked - contractualHours;
            }

            return (decimal)holidayHours;
        }

        public decimal HolidayRate(decimal holidayRate)
        {
            holidayRate *= 2m;
            return (decimal)holidayRate;
        }

        public decimal NetPay(decimal totalEarnings, decimal totalDeduction)
        {
            totalNetPay = totalEarnings - totalDeduction;
            return totalNetPay;
        }

        public decimal OvertimeEarning(decimal overtimeRate, decimal overtimeHours)
        {
            totalOvertimeEarning = overtimeRate * overtimeHours;
            return totalOvertimeEarning;
        }

        public decimal OverTimeHours(decimal hoursWorked, decimal contractualHours)
        {
            if (hoursWorked <= contractualHours)
            {
                overtimeHours = 0.00m;
            }
            else if (hoursWorked > contractualHours)
            {
                overtimeHours = hoursWorked - contractualHours;
            }

            return (decimal)overtimeHours;
        }

        public decimal OvertimeRate(decimal hourlyRate)
        {
            overtimeRate = hourlyRate * 1.5m;
            return (decimal)overtimeRate;
        }

        public decimal TotalDeduction(decimal itax, decimal nis, decimal nhttax, decimal edutax, decimal loan, decimal slb)
        {
            totalDeduction = itax + nis + nhttax + edutax + loan + slb;
            return totalDeduction;
        }

        public decimal TotalEarnings(decimal overtimeEarnings, decimal contractualEarnings)
        {
            totalEranings = overtimeEarnings + contractualEarnings;
            return totalEranings;
        }
    }
}
