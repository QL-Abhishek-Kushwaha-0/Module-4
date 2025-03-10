using DemoWebAPI.DTO;
using DemoWebAPI.Models.Entities;

namespace DemoWebAPI.Services
{
    public interface IEmployeeServices
    {
        List<Employee> GetAllEmployees();
        Employee? GetEmployeeById(Guid id);

        Employee AddEmployee(AddEmployeeDto Employee);

        bool UpdateEmployee(Guid id, UpdateEmployeeDto UpdatedEmployee);

        bool DeleteEmployee(Guid id);
    }
}
