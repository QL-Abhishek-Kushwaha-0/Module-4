using DemoWebAPI.DTO;
using DemoWebAPI.Models.Entities;
using DemoWebAPI.Repositories;

namespace DemoWebAPI.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _EmployeeRepository;

        public EmployeeServices(IEmployeeRepository employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
        }

        public List<Employee> GetAllEmployees()
        {
            return _EmployeeRepository.GetAllEmployees();
        }
        public Employee? GetEmployeeById(Guid id)
        {
            return _EmployeeRepository.GetEmployeeById(id);
        }

        public Employee AddEmployee(AddEmployeeDto Employee)
        {
            var EmployeeEntity = new Employee()
            {
                Name = Employee.Name,
                Email = Employee.Email,
                Phone = Employee.Phone,
                Salary = Employee.Salary,
            };
            return _EmployeeRepository.AddEmployee(EmployeeEntity);
        }

        public bool UpdateEmployee(Guid id, UpdateEmployeeDto UpdatedEmployee)
        {
            var Employee = _EmployeeRepository.GetEmployeeById(id);

            if (Employee == null) return false;

            return _EmployeeRepository.UpdateEmployee(Employee, UpdatedEmployee);
        }

        public bool DeleteEmployee(Guid id)
        {
            var Employee = _EmployeeRepository.GetEmployeeById(id);

            if (Employee is null) return false;

            return _EmployeeRepository.DeleteEmployee(Employee);
        }
    }
}
