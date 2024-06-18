using Microsoft.Extensions.Logging;
using Milliken.LibrarySystem.Models;
using Milliken.LibrarySystem.Interfaces;

namespace Milliken.LibrarySystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly Library _library;
        private readonly ILogger<EmployeeService> _log;
        private readonly Random _random = new Random();
        public List<Employee> Employees { get; set; } = new List<Employee>();
        private readonly List<Employee> AllEmployees = new List<Employee>()
        {
             new("Ethan", EmployeePositions.Manager, 29, 1),
             new("Sophia", EmployeePositions.Manager, 28, 2),
             new("John", EmployeePositions.Librarian, 31, 3),
             new("Hailey", EmployeePositions.Librarian, 28, 4),
             new("Justin", EmployeePositions.Assistant, 29, 5),
             new("Jane", EmployeePositions.Assistant, 30, 6),
             new("Harry", EmployeePositions.Intern, 21, 7),
             new("Elizabeth", EmployeePositions.Intern, 21, 8),
             new("Sam", EmployeePositions.Intern, 22, 9),
             new("Clarissa", EmployeePositions.Intern, 23, 10)
        };
        // Constructor DI
        public EmployeeService(Library library, ILogger<EmployeeService> log)
        {
            _library = library;
            _log = log;
            InitializeEmployeeData();
        }

        public void InitializeEmployeeData()
        {
            for (int i = 0; i < 7; i++)
            {
                int randomIndex = _random.Next(0, AllEmployees.Count);
                Employee selectedEmployee = AllEmployees[randomIndex];
                Employees.Add(selectedEmployee);
                AllEmployees.Remove(selectedEmployee);
            }
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
        public Employee FindEmployeeByID(int id)
        {
            foreach (var employee in Employees)
            {
                if (employee.EmployeeID == id)
                {
                    return employee;
                }
            }
            return null;
        }

        public List<Employee> RemoveEmployeeByID(int id)
        {
            var employee = FindEmployeeByID(id);
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
        public List<Employee> ListAllEmployeesByPosition(EmployeePositions position)
        {
            List<Employee> samePosition = new List<Employee>();
            _log.LogInformation($"{position}s");
            foreach (var employee in Employees)
            {
                if (employee.Position == position)
                {
                    _log.LogInformation($"-{employee.Name}");
                    samePosition.Add(employee);
                }
            }
            return samePosition;
        }
        public int TotalEmployees()
        {
            _log.LogInformation($"Number of employees in library: {Employees.Count}");
            return Employees.Count;
        }
    }
}
