using DemoEmployeePj.Dtos;
using DemoEmployeePj.Models;

namespace DemoEmployeePj.Mappers
{
    public interface IEmployeeMapper
    {
        Employee EmployeeCreateDtoToEmployee(EmployeeCreateDto employeeCreateDto);
        EmployeeGetDto EmployeeToEmployeeGetDto(Employee employee);
        List<EmployeeGetDto> EmployeeListToEmployeeGetDtoList(List<Employee> employeeList);
    }
}
