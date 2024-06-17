using Milliken.LibraryAPI.Models;
using Milliken.LibraryAPI.Interfaces;
using Microsoft.Extensions.Logging;

namespace Milliken.LibraryAPI.Services
{
    public class EBookService : IEBookService
    {
        private readonly Library _library;
        private readonly ILogger<EBookService> _log;
        public List<EBook> EBooks { get; set; } = new List<EBook>();
        // Constructor DI
        public EBookService(Library library, ILogger<EBookService> log)
        {
            _library = library;
            _log = log;
            InitializeEBookData();
        }
        
        public void InitializeEBookData()
        {
            // Create EBooks
            EBook ebook1 = new("The Hobbit", "J. R. R. Tolkien", 346, 1937, 1.5);
            EBook ebook2 = new("The Lightning Thief", "Rick Riordan", 380, 2005, 2.0);
            EBook ebook3 = new("The Martian", "Andy Weir", 450, 2011, 2.1);
            EBook ebook4 = new("Precious", "Sapphire", 241, 1996, 1.2);
            EBook ebook5 = new("Beloved", "Toni Morrison", 289, 1987, 1.4);

            EBooks.Add(ebook1);
            EBooks.Add(ebook2);
            EBooks.Add(ebook3);
            EBooks.Add(ebook4);
            EBooks.Add(ebook5);
        }
        // List EBooks
        public List<EBook> ListEBooks()
        {
            _log.LogInformation($"EBooks in {_library.Name}:");
            foreach (var eBook in EBooks)
            {
                _log.LogInformation($"- {eBook.Title} by {eBook.Author} published in {eBook.YearPublished}");
            }
            _log.LogInformation("\n -------------------------------------- \n");
            return EBooks;
        }

        // Find EBook
        public EBook FindEBookByTitle(string title)
        {
            foreach (var eBook in EBooks)
            {
                if (eBook.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    return eBook;
                }
            }
            return null;
        }

        public List<EBook> RemoveEBooksByTitle(string title)
        {
            var eBook = FindEBookByTitle(title);
            if (eBook != null)
            {
                EBooks.Remove(eBook);
            }
            return EBooks;
        }
        // Adding EBooks
        public List<EBook> AddEBooks(string title, string author, int pages, int yearPublished, double fileSize)
        {
            var eBook = new EBook(title, author, pages, yearPublished, fileSize);
            EBooks.Add(eBook);
            return EBooks;
        }
        public int TotalEBooks()
        {
            _log.LogInformation($"Number of electronic books in library: {EBooks.Count}");
            return EBooks.Count;
        }
    }
}