using System;

namespace Milliken.LibrarySystem.Models
{
    public class Book
    {
        // Properties
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; } = 0;
        public int YearPublished { get; set; } = 0;

        // Parameterized Constructor
        public Book(string title, string author, int pages, int yearPublished)
        {
            Title = title;
            Author = author;
            Pages = pages;
            YearPublished = yearPublished;
        }
    }
}