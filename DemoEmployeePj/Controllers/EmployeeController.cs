using DemoEmployeePj.Data;
using DemoEmployeePj.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoEmployeePj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetEmployees()
        {
            List<Employee> employees = EmployeeData.Employees; //Gets the employeed from the storage as the main model

            return Ok(employees);
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            return Created();
        }
    }
}
