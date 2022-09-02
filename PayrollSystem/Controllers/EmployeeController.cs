using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting.Internal;
using PayrollSystem.Entity;
using PayrollSystem.Models;
using PayrollSystem.Services;





namespace PayrollSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmloyeeService employeeService;
        private readonly IWebHostEnvironment hostingEnvironment;

        public EmployeeController(IEmloyeeService employeeService, IWebHostEnvironment hostingEnvironment)
        {
            this.employeeService = employeeService;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var employees = employeeService.GetAll().Select(employee => new EmployeeIndexViewModel
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                ImageUrl = employee.ImageUrl,
                FullName = employee.FullName,
                Gender = employee.Gender,
                Designation = employee.Designation,
                Address = employee.Address,
                DateJoined = employee.DateJoined,
            }).ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new EmployeeCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeCreateViewModel model, IFormFile ImageUrl)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Id = model.Id,
                    EmployeeNo = model.EmployeeNo,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    FullName = model.FullName,
                    Gender = model.Gender,
                    Email = model.Email,
                    DOB = model.DOB,
                    PhoneNumber = model.PhoneNumber,
                    DateJoined = model.DateJoined,
                    NationalInsuranceScheme = model.NationalInsuranceScheme,
                    TaxRegistrationNumber = model.TaxRegistrationNumber,
                    PaymentMethod = model.PaymentMethod,
                    Loan = model.Loan,
                    UnionMember = model.UnionMember,
                    Address = model.Address,
                    Parish = model.Parish,
                    Designation = model.Designation,
                };
                if (ImageUrl != null && ImageUrl.Length > 0)
                {
                    var uploadDir = @"C:/Users/Kemar/Desktop/All Projects/Active Progect/PayrollSestem/PayrollSystem/wwwroot/images/employees";
                    var fileNmae = Path.GetFileNameWithoutExtension(ImageUrl.FileName);
                    var extension = Path.GetExtension(ImageUrl.FileName);
                    var webRootPath = hostingEnvironment.ContentRootPath;
                    var fileName = DateTime.Now.ToString("yymmssfff") + fileNmae + extension;
                    var path = Path.Combine(webRootPath, uploadDir, fileNmae);
                    await ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDir + "/" + fileName;
                }
                await employeeService.CreateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var model = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                Gender = employee.Gender,
                Email = employee.Email,
                DOB = employee.DOB,
                PhoneNumber = employee.PhoneNumber,
                DateJoined = employee.DateJoined,
                NationalInsuranceScheme = employee.NationalInsuranceScheme,
                TaxRegistrationNumber = employee.TaxRegistrationNumber,
                PaymentMethod = employee.PaymentMethod,
                Loan = employee.Loan,
                UnionMember = employee.UnionMember,
                Address = employee.Address,
                Parish = employee.Parish,
                Designation = employee.Designation,
            };
            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = employeeService.GetById(model.Id);
                if (employee == null)
                {
                    return NotFound();
                }
                employee.EmployeeNo = employee.EmployeeNo;
                employee.FirstName = employee.FirstName;
                employee.MiddleName = employee.MiddleName;
                employee.LastName = employee.LastName;
                employee.Gender = employee.Gender;
                employee.Email = employee.Email;
                employee.DOB = employee.DOB;
                employee.PhoneNumber = employee.PhoneNumber;
                employee.DateJoined = employee.DateJoined;
                employee.NationalInsuranceScheme = employee.NationalInsuranceScheme;
                employee.TaxRegistrationNumber = employee.TaxRegistrationNumber;
                employee.PaymentMethod = employee.PaymentMethod;
                employee.Loan = employee.Loan;
                employee.UnionMember = employee.UnionMember;
                employee.Address = employee.Address;
                employee.Parish = employee.Parish;
                employee.Designation = employee.Designation;
                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"C:/Users/Kemar/Desktop/All Projects/Active Progect/PayrollSestem/PayrollSystem/wwwroot/images/employees";
                    var fileNmae = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var webRootPath = hostingEnvironment.ContentRootPath;
                    var fileName = DateTime.Now.ToString("yymmssfff") + fileNmae + extension;
                    var path = Path.Combine(webRootPath, uploadDir, fileNmae);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDir + "/" + fileName;
                }
                await employeeService.UpdateAsync(employee);
                return RedirectToAction(nameof(Index));

            }
            return View(model);
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Detail(int id)
        {
            var employee = employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            EmployeeDetailViewModel model = new EmployeeDetailViewModel()
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FullName = employee.FullName,
                Gender = employee.Gender,
                Email = employee.Email,
                DOB = employee.DOB,
                PhoneNumber = employee.PhoneNumber,
                DateJoined = employee.DateJoined,
                NationalInsuranceScheme = employee.NationalInsuranceScheme,
                TaxRegistrationNumber = employee.TaxRegistrationNumber,
                PaymentMethod = employee.PaymentMethod,
                Loan = employee.Loan,
                UnionMember = employee.UnionMember,
                Address = employee.Address,
                Parish = employee.Parish,
                Designation = employee.Designation,
                DateTerminated = employee.DateTerminated,
                ImageUrl = employee.ImageUrl,
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var emopployee = employeeService.GetById(id);
            if (emopployee == null)
            {
                return NotFound();
            }
            var model = new EmployeeDeleteViewModel()
            {
                Id = emopployee.Id,
                FullName = emopployee.FullName,
                Email = emopployee.Email,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EmployeeDeleteViewModel model)
        {
            await employeeService.DeleteAsync(model.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
