using DemoEmployeePj.Data;
using DemoEmployeePj.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoEmployeePj.Repo
{
    public class SqlServerRepoService : IRepoService
    {
        private readonly ApplicationDbContext _dbContext;

        public SqlServerRepoService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateEmployee(Employee employee)
        {
            await _dbContext.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            List<Employee> employees = new List<Employee>();
            employees= await _dbContext.Employees.ToListAsync();

            return employees;
        }
    }
}
