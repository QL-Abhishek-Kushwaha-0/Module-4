using DemoWebAPI.Data;
using DemoWebAPI.DTO;
using DemoWebAPI.Models.Entities;

namespace DemoWebAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _DbContext;
        public EmployeeRepository(ApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public List<Employee> GetAllEmployees() => _DbContext.Employees.ToList();

        public Employee GetEmployeeById(Guid id)
        {
            return _DbContext.Employees.Find(id);
        }

        public Employee AddEmployee(Employee employee)
        {
            _DbContext.Employees.Add(employee);
            _DbContext.SaveChanges();  // Required to Save Changes to the database
            return employee;
        }

        public bool UpdateEmployee(Employee employee, UpdateEmployeeDto UpdatedEmployee)
        {
            employee.Name = UpdatedEmployee.Name ?? employee.Name;
            employee.Email = UpdatedEmployee.Email ?? employee.Email;
            employee.Phone = UpdatedEmployee.Phone ?? employee.Phone;
            employee.Salary = UpdatedEmployee.Salary;

            _DbContext.SaveChanges();
            return true;
        }

        public bool DeleteEmployee(Employee employee)
        {
            _DbContext.Employees.Remove(employee);

            _DbContext.SaveChanges();

            return true;
        }
    }
}
