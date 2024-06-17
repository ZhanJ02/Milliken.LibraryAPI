using Microsoft.AspNetCore.Mvc;
using Milliken.LibraryAPI.Interfaces;
using Milliken.LibraryAPI.Models;

namespace Milliken.LibraryAPI.Controllers
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

        [HttpDelete("Deleting Employees by Name")]
        public List<Employee> DeleteEmployees(string name)
        {
            _employeeService.RemoveEmployeeByName(name);
            return _employeeService.ListEmployees();
        }

        [HttpPost("Add Employees to Library")]
        public List<Employee> AddEmployees(string name, EmployeePositions position, int age, int employeeID)
        {
            _employeeService.AddEmployees(name, position, age, employeeID);
            return _employeeService.ListEmployees();
        }

        [HttpPost("List All Employees by Position")]
        public List<Employee> ListAllEmployeesByPosition(EmployeePositions position)
        {
            return _employeeService.ListAllEmployeesByPosition(position);
        }

        [HttpGet("Total Employees")]
        public int TotalEmployees()
        {
            return _employeeService.TotalEmployees();
        }

    }
}