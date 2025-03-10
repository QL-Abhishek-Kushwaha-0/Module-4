using DemoWebAPI.Data;
using DemoWebAPI.DTO;
using DemoWebAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoWebAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _DbContext;
        public EmployeeRepository(ApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<List<Employee>> GetAllEmployees() => await _DbContext.Employees.ToListAsync();

        public async Task<Employee> GetEmployeeById(Guid id)
        {
            return await _DbContext.Employees.FindAsync(id);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            await _DbContext.Employees.AddAsync(employee);
            await _DbContext.SaveChangesAsync();  // Required to Save Changes to the database
            return employee;
        }

        public async Task<bool> UpdateEmployee(Employee employee, UpdateEmployeeDto UpdatedEmployee)
        {
            employee.Name = UpdatedEmployee.Name ?? employee.Name;
            employee.Email = UpdatedEmployee.Email ?? employee.Email;
            employee.Phone = UpdatedEmployee.Phone ?? employee.Phone;
            employee.Salary = UpdatedEmployee.Salary;

            await _DbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEmployee(Employee employee)
        {
            _DbContext.Employees.Remove(employee);  // No need to use await with Remove as it does not returnn any valuess

            await _DbContext.SaveChangesAsync();

            return true;
        }
    }
}
