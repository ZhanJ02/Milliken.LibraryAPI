using Milliken.LibrarySystem.Models;
using Milliken.LibrarySystem.Interfaces;
using Microsoft.Extensions.Logging;

namespace Milliken.LibrarySystem.Services
{
    public class EBookService : IEBookService
    {
        private readonly Library _library;
        private readonly ILogger<EBookService> _log;
        public List<EBook> EBooks { get; set; } = new List<EBook>();
        private readonly Random _random = new Random();
        private readonly List<EBook> AllEBooks = new List<EBook>()
        {
             new("Harry Potter and the Goblet of Fire", "J.K. Rowling", 550, 2000, 2.5, true),
             new("To Kill a Mockingbird", "Harper Lee", 320, 1960, 2.9, false),
             new("1984", "George Orwell", 398, 1949, 1.9, false),
             new("The Stranger", "Albert Camus", 320, 1942, 1.7, true),
             new("Harry Potter and the Sorcerer's Stone", "J.K. Rowling", 311, 1997, 3.9, false),
             new("The Hobbit", "J. R. R. Tolkien", 346, 1937, 1.5, true),
             new("The Lightning Thief", "Rick Riordan", 380, 2005, 2.0, true),
             new("The Martian", "Andy Weir", 450, 2011, 2.1, false),
             new("Precious", "Sapphire", 241, 1996, 1.2, true),
             new("Beloved", "Toni Morrison", 289, 1987, 1.4, true)
        };
        // Constructor DI
        public EBookService(Library library, ILogger<EBookService> log)
        {
            _library = library;
            _log = log;
            InitializeEBookData();
        }
        
        public void InitializeEBookData()
        {
            for (int i = 0; i < 5; i++)
            {
                int randomIndex = _random.Next(0, AllEBooks.Count);
                EBook selectedEBook = AllEBooks[randomIndex];
                EBooks.Add(selectedEBook);
                AllEBooks.Remove(selectedEBook);
            }
        }
        // List EBooks
        public List<EBook> ListEBooks()
        {
            _log.LogInformation($"EBooks in {_library.Name}:");
            foreach (var eBook in EBooks)
            {
                _log.LogInformation($"- {eBook.Title} by {eBook.Author} published in {eBook.YearPublished}, Is Available to Checkout: {eBook.IsAvailable}");
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
        public List<EBook> AddEBooks(string title, string author, int pages, int yearPublished, double fileSize, bool isAvailable)
        {
            var eBook = new EBook(title, author, pages, yearPublished, fileSize, isAvailable);
            EBooks.Add(eBook);
            return EBooks;
        }
        public EBook CheckoutEBook(string title)
        {
            var eBook = FindEBookByTitle(title);
            if (eBook != null && eBook.IsAvailable == true)
            {
                eBook.IsAvailable = false;
                _log.LogInformation($"{eBook.Title} is now checked out");
                return eBook;
            }
            else
            {
                _log.LogInformation($"{title} is not available.");
            }
            return null;
        }
        public EBook ReturnEBook(string title)
        {
            var eBook = FindEBookByTitle(title);
            if (eBook != null && eBook.IsAvailable == false)
            {
                eBook.IsAvailable = true;
                _log.LogInformation($"{title} has been returned");
            }
            else
            {
                _log.LogInformation($"{title} is already in library");
            }
            return null;

        }
        public int TotalEBooks()
        {
            _log.LogInformation($"Number of electronic books in library: {EBooks.Count}");
            return EBooks.Count;
        }
    }
}