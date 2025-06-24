using DemoEmployeePj.Models;

namespace DemoEmployeePj.Data
{
    public static class EmployeeData
    {
        public static List<Employee> Employees { get; set; } = new List<Employee>
        {
            new Employee
            {
                Id = Guid.Parse("3fda6b3b-5cc6-4bc2-bcb5-4a75b8c3340a"),
                Name = "Tunde",
            },
            new Employee
            {
                Id = Guid.Parse("b75eae57-3dc7-4268-94f6-2b98c1dcd42f"),
                Name = "Oba"
            }
        };
    }
}
