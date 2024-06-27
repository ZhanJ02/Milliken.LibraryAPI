using Milliken.LibrarySystem.Models;

namespace Milliken.LibrarySystem.Interfaces
{
    public interface IEBookService
    {
        List<EBook> ListEBooks();
        EBook FindEBookByTitle(string title);
        List<EBook> RemoveEBooksByTitle(string title);
        List<EBook> AddEBooks(string title, string author, int pages, int yearPublished, double fileSize, bool isAvailable);
        EBook CheckoutEBook(string title);
        EBook ReturnEBook(string title);
        int TotalEBooks();

    }
}