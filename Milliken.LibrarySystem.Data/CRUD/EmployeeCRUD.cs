using Microsoft.Extensions.Options;
using Milliken.LibrarySystem.Core.Models;
using System.Data.SqlClient;
using Dapper;

namespace Milliken.LibrarySystem.Data.CRUD
{
    public class EmployeeCRUD
    {
        private readonly IOptions<SqlSettings> _sqlOptions;
        private readonly string? _connectionString;
        public List<Employee> Employees { get; set; } = new List<Employee>();
        // Constructor DI
        public EmployeeCRUD(IOptions<SqlSettings> sqlOptions)
        {
            _sqlOptions = sqlOptions;
            _connectionString = _sqlOptions.Value?.DbSettings?
                .SingleOrDefault(name => name.Name == "libraryDb")?.ConnectionString;
        }

        public List<Employee> InitializeEmployee()
        {
            using var connection = new SqlConnection(_connectionString);
            string sqlQuery = "select Name, Position, Age, EmployeeID, IsWorking from Employee;";
            var tableData = connection.Query(sqlQuery);
            foreach (var row in tableData)
            {
                var employee = new Employee(row.Name, EmployeePositions.Intern, row.Age, row.EmployeeID, false);
                switch (row.Genre)
                {
                    case 0:
                        employee.Position = EmployeePositions.Manager;
                        break;
                    case 1:
                        employee.Position = EmployeePositions.Assistant;
                        break;
                    case 2:
                        employee.Position = EmployeePositions.Librarian;
                        break;
                }
                if (Convert.ToInt16(row.IsWorking) == 0)
                {
                    employee.IsWorking = false;
                }
                else
                {
                    employee.IsWorking = true;
                }
                Employees.Add(employee);
            }
            return Employees;
        }
    }
}
