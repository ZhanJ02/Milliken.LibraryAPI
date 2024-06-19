using Milliken.LibrarySystem.Models;

namespace Milliken.LibrarySystem.Interfaces
{
    public interface IBookService
    {
        void InitializeBookData();
        List<Book> ListBooks();
        Book FindBookByTitle(string title);
        List<Book> RemoveBooksByTitle(string title);
        List<Book> AddBooks(string title, string author, int pages, int yearPublished, bool isAvailable);
        Book CheckoutBook(string title);
        Book ReturnBook(string title);
        int TotalBooks();
    }
}