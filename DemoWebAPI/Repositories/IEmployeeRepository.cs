using DemoWebAPI.DTO;
using DemoWebAPI.Models.Entities;

namespace DemoWebAPI.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(Guid id);
        Employee AddEmployee(Employee Employee);
        bool UpdateEmployee(Employee employee, UpdateEmployeeDto UpdatedEmployee);
        bool DeleteEmployee(Employee employee);
    }
}
