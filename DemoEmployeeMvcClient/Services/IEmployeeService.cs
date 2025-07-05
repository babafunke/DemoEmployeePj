using DemoEmployeeMvcClient.Models;

namespace DemoEmployeeMvcClient.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeGetDto>> GetAll();
        Task<bool> CreateEmployee(EmployeeCreateDto employeeCreateDto);
    }
}
