using Milliken.LibraryAPI.Models;

namespace Milliken.LibraryAPI.Interfaces
{
    public interface IEBookService
    {
        // Interface for Library class
        void InitializeEBookData();
        List<EBook> ListEBooks();
        EBook FindEBookByTitle(string title);
        List<EBook> RemoveEBooksByTitle(string title);
        List<EBook> AddEBooks(string title, string author, int pages, int yearPublished, double fileSize);
        int TotalEBooks();

    }
}