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
                DateTerminated = employee.DateTerminated
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
        public async Task<IActionResult> Create(EmployeeCreateViewModel model)
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
                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"images/employees";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var webRootPath = hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
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
                DateTerminated = employee.DateTerminated,
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
                employee.EmployeeNo = model.EmployeeNo;
                employee.FirstName = model.FirstName;
                employee.MiddleName = model.MiddleName;
                employee.LastName = model.LastName;
                employee.Gender = model.Gender;
                employee.Email = model.Email;
                employee.DOB = model.DOB;
                employee.PhoneNumber = model.PhoneNumber;
                employee.DateJoined = model.DateJoined;
                employee.DateTerminated = model.DateTerminated;
                employee.NationalInsuranceScheme = model.NationalInsuranceScheme;
                employee.TaxRegistrationNumber = model.TaxRegistrationNumber;
                employee.PaymentMethod = model.PaymentMethod;
                employee.Loan = model.Loan;
                employee.UnionMember = model.UnionMember;
                employee.Address = model.Address;
                employee.Parish = model.Parish;
                employee.Designation = model.Designation;
                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"images/employees";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var webRootPath = hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDir + "/" + fileName;
                }
                await employeeService.UpdateAsync(employee);
                return RedirectToAction(nameof(Index));

            }
            return View(model);
        }

        [HttpGet]
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
                Address = employee.Address,
                Parish = employee.Parish,
                Designation = employee.Designation,
                DateTerminated = employee.DateTerminated,
                ImageUrl = employee.ImageUrl
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
