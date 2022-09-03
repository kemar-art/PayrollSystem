using Microsoft.AspNetCore.Mvc.Rendering;
using PayrollSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.Services
{
    public interface IPaymentService
    {
        Task CreateAsync(PaymentRecord paymentRecord);
        PaymentRecord GetById(int id);
        IEnumerable<PaymentRecord> GetAll();
        IEnumerable<SelectListItem> GetAllTaxYear();
        decimal OverTimeHours(decimal hoursWorked, decimal contractualHours);
        decimal HolidayHours(decimal hoursWorked, decimal contractualHours);
        decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate);
        decimal OvertimeRate(decimal hourlyRate);
        decimal HolidayRate(decimal holidayRate);
        decimal OvertimeEarning(decimal overtimeRate, decimal overtimeHours);
        decimal HolidayEarning(decimal holidayRate, decimal holidayHours);
        decimal TotalEarnings(decimal overtimeEarnings, decimal contractualEarnings);
        decimal TotalDeduction(decimal itax, decimal nis, decimal nhttax, decimal edutax, decimal loan, decimal slb);
        decimal NetPay(decimal totalEarnings, decimal totalDeduction);
        
    }
}
