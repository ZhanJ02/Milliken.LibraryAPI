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
             new("Ethan", EmployeePositions.Manager, 29, 1, true),
             new("Sophia", EmployeePositions.Manager, 28, 2, false),
             new("John", EmployeePositions.Librarian, 31, 3, false),
             new("Hailey", EmployeePositions.Librarian, 28, 4, false),
             new("Justin", EmployeePositions.Assistant, 29, 5, true),
             new("Jane", EmployeePositions.Assistant, 30, 6, true),
             new("Harry", EmployeePositions.Intern, 21, 7, true),
             new("Elizabeth", EmployeePositions.Intern, 21, 8, true),
             new("Sam", EmployeePositions.Intern, 22, 9, false),
             new("Clarissa", EmployeePositions.Intern, 2, 11, true),
             new("Emily", EmployeePositions.Intern, 23, 12, true)
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
            for (int i = 0; i < 9; i++)
            {
                int randomIndex = _random.Next(0, AllEmployees.Count);
                Employee selectedEmployee = AllEmployees[randomIndex];
                Employees.Add(selectedEmployee);
                AllEmployees.Remove(selectedEmployee);
            }
        }
        public List<Employee> ListEmployees()
        {
            _log.LogInformation($"Employees in {_library.Name}:");
            foreach (var employee in Employees)
            {
                _log.LogInformation($"- {employee.Name}: {employee.Position}, Age: {employee.Age}, ID: {employee.EmployeeID}, Currently Working Today: {employee.IsWorking}");
            }
            _log.LogInformation("\n -------------------------------------- \n");
            return Employees;
        }

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

        public List<Employee> AddEmployees(string name, EmployeePositions position, int age, int employeeID, bool isWorking)
        {
            var employee = new Employee(name, position, age, employeeID, isWorking);
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

        public Employee CheckIn(int id)
        {
            var employee = FindEmployeeByID(id);
            if (employee != null && employee.IsWorking == false)
            {
                employee.IsWorking = true;
                _log.LogInformation($"{employee.Name} is now working");
                return employee;
            } 
            else
            {
                _log.LogInformation($"{employee.Name} is already working");
            }
            return null;
        }
        public Employee CheckOut(int id)
        {
            var employee = FindEmployeeByID(id);
            if (employee != null && employee.IsWorking == true)
            {
                employee.IsWorking = false;
                _log.LogInformation($"{employee.Name} is checked out");
                return employee;
            }
            else
            {
                _log.LogInformation($"{employee.Name} is already checked out");
            }
            return null;
        }

        public int TotalEmployees()
        {
            _log.LogInformation($"Number of employees in library: {Employees.Count}");
            return Employees.Count;
        }
    }
}