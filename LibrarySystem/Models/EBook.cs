namespace Milliken.LibrarySystem.Models
{
    public class EBook : Book
    {
        // Properties
        public double FileSizeMB { get; set; }

        // Parameterized Constructor
        public EBook(string title, string author, int pages, int yearPublished, double fileSizeMB, bool isAvailable)
            : base(title, author, pages, yearPublished, isAvailable)
        {
            FileSizeMB = fileSizeMB;
        }
    }
}