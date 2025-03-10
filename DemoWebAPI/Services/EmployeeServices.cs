using DemoWebAPI.DTO;
using DemoWebAPI.Models.Entities;
using DemoWebAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DemoWebAPI.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _EmployeeRepository;

        public EmployeeServices(IEmployeeRepository employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _EmployeeRepository.GetAllEmployees();
        }

        public async Task<Employee?> GetEmployeeById(Guid id)    // Task<T> is nullable
        {
            return await _EmployeeRepository.GetEmployeeById(id);
        }

        public async Task<Employee?> AddEmployee(AddEmployeeDto Employee)
        {
            var EmployeeEntity = new Employee()
            {
                Name = Employee.Name,
                Email = Employee.Email,
                Phone = Employee.Phone,
                Salary = Employee.Salary,
            };
            return await _EmployeeRepository.AddEmployee(EmployeeEntity);
        }

        public async Task<bool> UpdateEmployee(Guid id, UpdateEmployeeDto UpdatedEmployee)
        {
            var Employee = await _EmployeeRepository.GetEmployeeById(id);

            if (Employee == null) return false;

            return await _EmployeeRepository.UpdateEmployee(Employee, UpdatedEmployee);
        }

        public async Task<bool> DeleteEmployee(Guid id)
        {
            var Employee = await _EmployeeRepository.GetEmployeeById(id);

            if (Employee is null) return false;

            return await _EmployeeRepository.DeleteEmployee(Employee);
        }
    }
}
