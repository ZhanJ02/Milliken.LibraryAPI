using Microsoft.AspNetCore.Mvc;
using Milliken.LibrarySystem.Core.Models;
using Milliken.LibrarySystem.Data.Interfaces;

namespace Milliken.LibrarySystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("Employees in Library")]
        public List<Employee> GetEmployees()
        {
            return _employeeService.ListEmployees();
        }

        [HttpDelete("Deleting Employees by ID")]
        public List<Employee> DeleteEmployees(int id)
        {
            _employeeService.RemoveEmployeeByID(id);
            return _employeeService.ListEmployees();
        }

        [HttpPost("Add Employees to Library")]
        public List<Employee> AddEmployees(string name, EmployeePositions position, int age, int employeeID, bool isWorking)
        {
            _employeeService.AddEmployees(name, position, age, employeeID, isWorking);
            return _employeeService.ListEmployees();
        }

        [HttpPost("List All Employees by Position")]
        public List<Employee> CheckOut(EmployeePositions position)
        {
            return _employeeService.ListAllEmployeesByPosition(position);
        }

        [HttpPost("Employee Check In")]
        public Employee CheckIn(int id)
        {
            return _employeeService.CheckIn(id);
        }

        [HttpPost("Employee Check Out")]
        public Employee CheckOut(int id)
        {
            return _employeeService.CheckOut(id);
        }

        [HttpGet("Total Employees")]
        public int TotalEmployees()
        {
            return _employeeService.TotalEmployees();
        }
    }
}