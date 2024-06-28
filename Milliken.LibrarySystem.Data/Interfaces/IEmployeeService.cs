using Milliken.LibrarySystem.Core.Models;

namespace Milliken.LibrarySystem.Data.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> ListEmployees();
        Employee FindEmployeeByID(int id);
        List<Employee> RemoveEmployeeByID(int id);
        List<Employee> AddEmployees(string name, EmployeePositions position, int age, int employeeID, bool isWorking);
        List<Employee> ListAllEmployeesByPosition(EmployeePositions position);
        Employee CheckIn(int employeeID);
        Employee CheckOut(int employeeID);
        int TotalEmployees();
    }
}
