using Milliken.LibraryAPI.Models;

namespace Milliken.LibraryAPI.Interfaces
{
    public interface IEmployeeService
    {
        void InitializeEmployeeData();
        List<Employee> ListEmployees();
        Employee FindEmployeeByName(string name);
        List<Employee> RemoveEmployeeByName(string name);
        List<Employee> AddEmployees(string name, EmployeePositions position, int age, int employeeID);
        List<Employee> ListAllEmployeesByPosition(EmployeePositions position);
        int TotalEmployees();
    }
}
