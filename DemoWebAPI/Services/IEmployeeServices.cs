using DemoWebAPI.DTO;
using DemoWebAPI.Models.Entities;

namespace DemoWebAPI.Services
{
    public interface IEmployeeServices
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee?> GetEmployeeById(Guid id);

        Task<Employee> AddEmployee(AddEmployeeDto Employee);

        Task<bool> UpdateEmployee(Guid id, UpdateEmployeeDto UpdatedEmployee);

        Task<bool> DeleteEmployee(Guid id);
    }
}
