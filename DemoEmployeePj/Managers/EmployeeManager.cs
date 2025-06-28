using DemoEmployeePj.Dtos;
using DemoEmployeePj.Mappers;
using DemoEmployeePj.Models;
using DemoEmployeePj.Repo;

namespace DemoEmployeePj.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IRepoService _repoService;
        private readonly IEmployeeMapper _employeeMapper;

        public EmployeeManager(IRepoService repoService, IEmployeeMapper employeeMapper)
        {
            _repoService = repoService;
            _employeeMapper = employeeMapper;
        }

        public async Task<string> CreateEmployee(EmployeeCreateDto employeeCreateDto)
        {
            Employee employee = _employeeMapper.EmployeeCreateDtoToEmployee(employeeCreateDto);

            employee.SimplifiedName = CreateSimplifiedName(employee.Name);

            await _repoService.CreateEmployee(employee);

            return "Successful";
        }

        public async Task<List<EmployeeGetDto>> GetEmployeesAsync()
        {
            List<Employee> employees = await _repoService.GetEmployeesAsync();

            List<EmployeeGetDto> employeesGetDtos = _employeeMapper.EmployeeListToEmployeeGetDtoList(employees);

            return employeesGetDtos;
        }

        private static string CreateSimplifiedName(string name)
        {
            string shortName = name.Substring(0, 3);

            return shortName;
        }
    }
}
