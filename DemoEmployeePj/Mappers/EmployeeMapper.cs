using DemoEmployeePj.Data;
using DemoEmployeePj.Dtos;
using DemoEmployeePj.Models;

namespace DemoEmployeePj.Mappers
{
    public class EmployeeMapper: IEmployeeMapper
    {
        public Employee EmployeeCreateDtoToEmployee(EmployeeCreateDto employeeCreateDto)
        {
            Employee employee = new Employee();
            employee.Id = Guid.NewGuid();
            employee.Name = employeeCreateDto.Name;
            //EmployeeData.Employees.Add(employee);
            return employee;
        }

        public EmployeeGetDto EmployeeToEmployeeGetDto(Employee employee)
        {
            EmployeeGetDto employeeGetDto = new EmployeeGetDto();
            employeeGetDto.Name = employee.Name;
            employeeGetDto.CreatedDate = employee.CreatedDate;
            return employeeGetDto;
        }

        public List<EmployeeGetDto> EmployeeListToEmployeeGetDtoList(List<Employee> employeeList)
        {
            List<EmployeeGetDto> employeeGetDtoList = new List<EmployeeGetDto>();

            foreach (var employee in employeeList)
            {
                EmployeeGetDto employeeGetDto = new EmployeeGetDto();
                employeeGetDto.Name = employee.Name;
                employeeGetDto.CreatedDate = employee.CreatedDate;

                employeeGetDtoList.Add(employeeGetDto);
            }
            return employeeGetDtoList;
        }
    }
}
