using System;

namespace Milliken.LibraryAPI.Models
{
    public class Employee
    {
        // Properties
        public string Name { get; set; }
        public string Position { get; set; }

        public int Age { get; set; }

        // Parameterized Constructor
        public Employee(string name, string position, int age)
        {
            Name = name;
            Position = position;
            Age = age;
        }
    }
}