using Milliken.LibrarySystem.Models;
using Milliken.LibrarySystem.Interfaces;
using Microsoft.Extensions.Logging;
using Milliken.LibrarySystem.CRUD;

namespace Milliken.LibrarySystem.Services
{
    public class EBookService : IEBookService
    {
        private readonly Library _library;
        private readonly ILogger<EBookService> _log;
        private readonly EBookCRUD _eBookCRUD;
        public List<EBook> EBooks { get; set; } = new List<EBook>(); 
        // Constructor DI
        public EBookService(Library library, ILogger<EBookService> log, EBookCRUD eBookCRUD)
        {
            _eBookCRUD = eBookCRUD;
            _library = library;
            _log = log;
        }

        public List<EBook> ListEBooks()
        {
            EBooks = (_eBookCRUD.CreateEBook());
            _log.LogInformation($"EBooks in {_library.Name}:");
            foreach (var eBook in EBooks)
            {
                _log.LogInformation($"- {eBook.Title} by {eBook.Author} published in {eBook.YearPublished}, Is Available to Checkout: {eBook.IsAvailable}");
            }
            _log.LogInformation("\n -------------------------------------- \n");
            return EBooks;
        }

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
            int count = 0;
            foreach ( var eBook in EBooks )
            {
                if ( eBook.IsAvailable == true )
                {
                    count++;
                }
            }
            _log.LogInformation($"Number of available electronic books in library: {count}");
            return count;
        }
    }
}