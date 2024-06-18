using Milliken.LibrarySystem.Models;

namespace Milliken.LibrarySystem.Interfaces
{
    public interface IBookService
    {
        // Interface for Library class
        void InitializeBookData();
        List<Book> ListBooks();
        Book FindBookByTitle(string title);
        List<Book> RemoveBooksByTitle(string title);
        List<Book> AddBooks(string title, string author, int pages, int yearPublished, bool isAvailable);
        int TotalBooks();
    }
}