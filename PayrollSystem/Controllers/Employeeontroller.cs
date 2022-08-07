using Microsoft.AspNetCore.Mvc;
using PayrollSystem.Models;
using PayrollSystem.Services;

namespace PayrollSystem.Controllers
{
    public class Employeeontroller : Controller
    {
        private readonly IEmloyeeService employeeService;

        public Employeeontroller(IEmloyeeService employeeService)
        {
            this.employeeService = employeeService;
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
                Parish = employee.Parish,
                DateJoined = employee.DateJoined,
            }).ToList();
            return View(employees);
        }
    }
}
