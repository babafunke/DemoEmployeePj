using DemoEmployeePj.Dtos;
using DemoEmployeePj.Managers;
using Microsoft.AspNetCore.Mvc;

namespace DemoEmployeePj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            List<EmployeeGetDto> employees = await _employeeManager.GetEmployeesAsync();

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateDto employeeCreateDto)
        {
            string result = await _employeeManager.CreateEmployee(employeeCreateDto);

            return Ok(result);
        }
    }
}
