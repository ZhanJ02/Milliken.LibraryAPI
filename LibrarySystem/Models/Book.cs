namespace Milliken.LibrarySystem.Models
{
    public class Book
    {
        // Properties
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public int YearPublished { get; set; }
        public bool IsAvailable { get; set; }

        // Parameterized Constructor
        public Book(string title, string author, int pages, int yearPublished, bool isAvailable)
        {
            Title = title;
            Author = author;
            Pages = pages;
            YearPublished = yearPublished;
            IsAvailable = isAvailable;
        }
    }
}