namespace Milliken.LibrarySystem.Models
{
    public enum EmployeePositions
    {
        Manager,
        Librarian,
        Assistant,
        Intern
    }
    public class Employee
    {
        // Properties
        public string Name { get; set; }
        public EmployeePositions Position { get; set; }

        public int Age { get; set; }
        public int EmployeeID { get; set; }
        public bool IsWorking { get; set; }

        // Parameterized Constructor
        public Employee(string name, EmployeePositions position, int age, int employeeID, bool isWorking)
        {
            Name = name;
            Position = position;
            Age = age;
            EmployeeID = employeeID;
            IsWorking = isWorking;
        }
    }
}