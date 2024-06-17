using Milliken.LibraryAPI.Models;

namespace Milliken.LibraryAPI.Interfaces
{
    public interface IEmployeeService
    {
        void InitializeEmployeeData();
        List<Employee> ListEmployees();
        Employee FindEmployeeByID(int id);
        List<Employee> RemoveEmployeeByID(int id);
        List<Employee> AddEmployees(string name, EmployeePositions position, int age, int employeeID);
        List<Employee> ListAllEmployeesByPosition(EmployeePositions position);
        int TotalEmployees();
    }
}
