using Milliken.LibraryAPI.Models;

namespace Milliken.LibraryAPI.Interfaces
{
    public interface ILibraryService
    {
        // Interface for Library class
        void InitializeBookData();
        void InitializeEBookData();
        List<Book> ListBooks();
        List<EBook> ListEBooks();
        Book FindBookByTitle(string title);
        EBook FindEBookByTitle(string title);
        List<Book> RemoveBooksByTitle(string title);
        List<EBook> RemoveEBooksByTitle(string title);
        List<Book> AddBooks(string title, string author, int pages, int yearPublished);
        List<EBook> AddEBooks(string title, string author, int pages, int yearPublished, double fileSize);
        int TotalBooksAndEBooks();
    }
}