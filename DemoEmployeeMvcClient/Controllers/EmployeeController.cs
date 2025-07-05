using DemoEmployeeMvcClient.Models;
using DemoEmployeeMvcClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoEmployeeMvcClient.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController (IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<IActionResult> Index()
        {
            List<EmployeeGetDto> employees = await _employeeService.GetAll();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateDto employeeCreateDto)
        {
            bool response = await _employeeService.CreateEmployee(employeeCreateDto);
            return RedirectToAction("Index");
        }
    }
}
