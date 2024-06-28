using Microsoft.Extensions.Logging;
using Milliken.LibrarySystem.Core.Models;
using Milliken.LibrarySystem.Data.Interfaces;
using Milliken.LibrarySystem.Data.CRUD;

namespace Milliken.LibrarySystem.Data.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly Library _library;
        private readonly ILogger<EmployeeService> _log;
        private readonly EmployeeCRUD _employeeCRUD;
        public List<Employee> Employees { get; set; } = new List<Employee>();
        // Constructor DI
        public EmployeeService(Library library, ILogger<EmployeeService> log, EmployeeCRUD employeeCRUD)
        {
            _library = library;
            _log = log;
            _employeeCRUD = employeeCRUD;
        }

        public List<Employee> ListEmployees()
        {
            Employees = _employeeCRUD.InitializeEmployee();
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