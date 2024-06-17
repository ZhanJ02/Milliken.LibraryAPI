using Microsoft.Extensions.Logging;
using Milliken.LibraryAPI.Models;
using Milliken.LibraryAPI.Interfaces;
using static System.Reflection.Metadata.BlobBuilder;

namespace Milliken.LibraryAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly Library _library;
        private readonly ILogger<EmployeeService> _log;
        public List<Employee> Employees { get; set; } = new List<Employee>();
        // Constructor DI
        public EmployeeService(Library library, ILogger<EmployeeService> log)
        {
            _library = library;
            _log = log;
            InitializeEmployeeData();
        }

        public void InitializeEmployeeData()
        {
            // Create EBooks
            Employee employee1 = new("Ethan", EmployeePositions.Manager, 29, 001);
            Employee employee2 = new("Clarissa", EmployeePositions.Librarian, 31, 002);
            Employee employee3 = new("Sam", EmployeePositions.Assistant, 26, 003);
            Employee employee4 = new("Sophie", EmployeePositions.Intern, 22, 004);
            Employee employee5 = new("Jessie", EmployeePositions.Intern, 22, 005);

            Employees.Add(employee1);
            Employees.Add(employee2);
            Employees.Add(employee3);
            Employees.Add(employee4);
            Employees.Add(employee5);
        }
        // List EBooks
        public List<Employee> ListEmployees()
        {
            _log.LogInformation($"Employees in {_library.Name}:");
            foreach (var employee in Employees)
            {
                _log.LogInformation($"- {employee.Name}: {employee.Position}, Age: {employee.Age}, ID: {employee.EmployeeID}");
            }
            _log.LogInformation("\n -------------------------------------- \n");
            return Employees;
        }

        // Find EBook
        public Employee FindEmployeeByName(string name)
        {
            foreach (var employee in Employees)
            {
                if (employee.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return employee;
                }
            }
            return null;
        }

        public List<Employee> RemoveEmployeeByName(string name)
        {
            var employee = FindEmployeeByName(name);
            if (employee != null)
            {
                Employees.Remove(employee);
            }
            return Employees;
        }
        // Adding EBooks
        public List<Employee> AddEmployees(string name, EmployeePositions position, int age, int employeeID)
        {
            var employee = new Employee(name, position, age, employeeID);
            Employees.Add(employee);
            return Employees;
        }
        public int TotalEmployees()
        {
            _log.LogInformation($"Number of employees in library: {Employees.Count}");
            return Employees.Count;
        }
    }
}
