using DemoEmployeePj.Dtos;

namespace DemoEmployeePj.Managers
{
    public interface IEmployeeManager
    {
        Task<List<EmployeeGetDto>> GetEmployeesAsync();
        Task<string> CreateEmployee(EmployeeCreateDto employee);
    }
}
