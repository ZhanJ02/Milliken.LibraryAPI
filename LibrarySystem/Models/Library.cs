﻿namespace Milliken.LibrarySystem.Core.Models
{
    public class Library
    {
        // Properties
        public string Name { get; set; }
        public string Location { get; set; }
        // Parameterized Constructor
        public Library(string name, string location)
        {
            Name = name;
            Location = location;
        }
    }
}