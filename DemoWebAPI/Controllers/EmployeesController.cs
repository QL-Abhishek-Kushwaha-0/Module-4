using DemoWebAPI.Data;
using DemoWebAPI.DTO;
using DemoWebAPI.Models.Entities;
using DemoWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // Employee Service Injection

        private readonly IEmployeeServices _EmployeeServices;

        public EmployeesController(IEmployeeServices EmployeeServices)
        {
            _EmployeeServices = EmployeeServices;
        }

        // API path to GET Details of ALl Employees
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var AllEmployees = await _EmployeeServices.GetAllEmployees();

            return Ok(AllEmployees);
        }


        // API Path to Get Details of Single Employee by ID
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetEmployeeByID(Guid id)
        {
            var Employee = await _EmployeeServices.GetEmployeeById(id);
            
            if (Employee == null) return NotFound("No User with this ID Exists!!!!");

            return Ok(Employee);
        }


        // API Path to Add Employee
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeDto Employee)
        {
            var EmployeeEntity = await _EmployeeServices.AddEmployee(Employee);

            return Ok(EmployeeEntity);
        }


        // API Path to update the details of the Employee
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, UpdateEmployeeDto UpdatedEmployee)
        {
            var updateStatus = await _EmployeeServices.UpdateEmployee(id, UpdatedEmployee);

            if (updateStatus == false) return NotFound("User with this ID Does Not Exists!!!!");

            return Ok("Employee Details Updated Successfullly!!!!");
        }


        // API Path to Delete the Employee
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var deleteStatus = await _EmployeeServices.DeleteEmployee(id);

            if (deleteStatus == false) return NotFound("No Such User Exists!!!!!");

            return Ok("Employee Details Deleted Successfully!!!!");
        }
    }
}
