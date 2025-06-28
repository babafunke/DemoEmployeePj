using DemoEmployeePj.Models;

namespace DemoEmployeePj.Repo
{
    public interface IRepoService
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task CreateEmployee(Employee employee);

    }
}
