using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string? EmployeeNo { get; set; }
        [Required, MaxLength(50)]
        public string? FirstName { get; set; }
        [Required, MaxLength(50)]
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? FullName { get; set; }
        [Required]
        public string? Address { get; set; }
        public string? Parish { get; set; }
        [Required, Display(Name = "Contact Number")]
        public string? PhoneNumber { get; set; }
        [Required, MaxLength(50)]
        public string? Gender { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime DateTerminated { get; set; }
        public string? Designation { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? TaxRegistrationNumber { get; set; }
        [Required]
        public string? NationalInsuranceScheme { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Loan Loan { get; set; }
        public UnionMember UnionMember { get; set; }
        public IEnumerable<PaymentRecord>? PaymentRecords { get; set; }
    }
}
