using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.Entity
{
    public class PaymentRecord
    {
        public int Id { get; set; }

        [ForeignKey ("EmployeeId")]
        public Employee? Employee { get; set; }
        public int EmployeeId { get; set; }

        public string? FullName { get; set; }
        public string? PayMonth { get; set; }
        public DateTime PayDate { get; set; }

        [ForeignKey("TaxYearId")]
        public TaxYear? TaxYear { get; set; }
        public int TaxYearId { get; set; }

        public string? TaxCode { get; set; }
        [Column(TypeName = "money")]
        public decimal HourlyRate { get; set; }
        [Column(TypeName = "decimal (18, 2)")]
        public decimal HoursWorked { get; set; }
        [Column(TypeName = "decimal (18, 2)")]
        public decimal ContractualHours { get; set; }
        [Column(TypeName = "decimal (18, 2)")]
        public decimal OvertimeHours { get; set; }
        [Column(TypeName = "decimal (18, 2)")]
        public decimal HolidayHours { get; set; }
        [Column(TypeName = "money")]
        public decimal ContractualEarnings { get; set; }
        [Column(TypeName = "money")]
        public decimal HolidayEarning { get; set; }
        [Column(TypeName = "money")]
        public decimal OvertimeEarnings { get; set; }
        [Column(TypeName = "money")]
        public decimal NISTax { get; set; }
        [Column(TypeName = "money")]
        public decimal NHTTax { get; set; }
        [Column(TypeName = "money")]
        public decimal EDUTax { get; set; }
        [Column(TypeName = "money")]
        public decimal IncomTax { get; set; }
        [Column(TypeName = "money")]
        public decimal? UnionFee { get; set; }
        [Column(TypeName = "money")]
        public decimal? SLB { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalEarnings { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalDeduction { get; set; }
        [Column(TypeName = "money")]
        public decimal NetSalary { get; set; }
        [Column(TypeName = "money")]
        public decimal AnnualGrossSalary { get; set; }
        [Column(TypeName = "money")]
        public decimal AnnualIncomTax { get; set; }
        [Column(TypeName = "money")]
        public decimal AnnualNISTax { get; set; }
        [Column(TypeName = "money")]
        public decimal AnnualEDUTax { get; set; }
        [Column(TypeName = "money")]
        public decimal AnnualNHTTas { get; set; }
        [Column(TypeName = "money")]
        public decimal AnnualNetSalary { get; set; }

    }
}
