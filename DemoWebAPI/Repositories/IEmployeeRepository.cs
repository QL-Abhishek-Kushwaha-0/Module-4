using DemoWebAPI.DTO;
using DemoWebAPI.Models.Entities;

namespace DemoWebAPI.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(Guid id);
        Task<Employee> AddEmployee(Employee Employee);
        Task<bool> UpdateEmployee(Employee employee, UpdateEmployeeDto UpdatedEmployee);
        Task<bool> DeleteEmployee(Employee employee);
    }
}
