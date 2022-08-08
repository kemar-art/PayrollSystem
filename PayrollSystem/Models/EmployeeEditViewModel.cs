using PayrollSystem.Entity;
using System.ComponentModel.DataAnnotations;

namespace PayrollSystem.Models
{
    public class EmployeeEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Emloyee Number is required"), RegularExpression(@"^[A-Z]{3,3}[0-9]{0}$")]
        public string? EmployeeNo { get; set; }
        [Required(ErrorMessage = "First Name is required"), Display(Name = "First Name"), MaxLength(50)]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required"), Display(Name = "Last Name"), MaxLength(50)]
        public string? LastName { get; set; }
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Parish is required")]
        public string? Parish { get; set; }
        [Required, Display(Name = "Contact Number")]
        public string? PhoneNumber { get; set; }
        [Required, MaxLength(50)]
        public string? Gender { get; set; }
        [Display(Name = "Photo")]
        public IFormFile ImageUrl { get; set; }
        [DataType(DataType.Date), Display(Name = ("D.O.B"))]
        public DateTime DOB { get; set; }
        [DataType(DataType.Date), Display(Name = ("Start Date"))]
        public DateTime DateJoined { get; set; } = DateTime.Now;
        [DataType(DataType.Date), Display(Name = ("Term Date"))]
        public DateTime DateTerminated { get; set; }
        [Required(ErrorMessage = "Job role is required"), Display(Name = "Job Role")]
        public string? Designation { get; set; }
        [Required(ErrorMessage = "Email address is required"), DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Tax Registration Number is required"), Display(Name = "T.R.N")]
        public string? TaxRegistrationNumber { get; set; }
        [Required(ErrorMessage = "National Insurance Scheme Number is required"), Display(Name = "T.R.N")]
        public string? NationalInsuranceScheme { get; set; }
        [Display(Name = ("Payment Method"))]
        public PaymentMethod PaymentMethod { get; set; }
        public Loan Loan { get; set; }
        [Display(Name = ("Union Member"))]
        public UnionMember UnionMember { get; set; }
    }
}
