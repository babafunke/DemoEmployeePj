using DemoEmployeePj.Data;
using DemoEmployeePj.Dtos;
using DemoEmployeePj.Mappers;
using DemoEmployeePj.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoEmployeePj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeMapper _employeeMapper; 
        public EmployeeController(IEmployeeMapper employeeMapper)
        {
            _employeeMapper = employeeMapper;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            List<Employee> employees = EmployeeData.Employees; //Gets the employeed from the storage as the main model

            List<EmployeeGetDto> employeesGetDto = new List<EmployeeGetDto>();

            employeesGetDto = _employeeMapper.EmployeeListToEmployeeGetDtoList(employees);

            return Ok(employeesGetDto);
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeCreateDto employeeCreateDto)
        {
            _employeeMapper.EmployeeCreateDtoToEmployee(employeeCreateDto);

            return Created();
        }
    }
}
