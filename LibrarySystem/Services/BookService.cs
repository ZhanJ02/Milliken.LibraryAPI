using Milliken.LibrarySystem.Models;
using Milliken.LibrarySystem.Interfaces;
using Milliken.LibrarySystem.CRUD;
using Microsoft.Extensions.Logging;

namespace Milliken.LibrarySystem.Services
{
    public class BookService : IBookService
    {
        private readonly Library _library;
        private readonly ILogger<BookService> _log;
        private readonly BookCRUD _bookCRUD;
        public List<Book> Books { get; set; } = new List<Book>();
        // Constructor DI
        public BookService(Library library, ILogger<BookService> log, BookCRUD bookCRUD)
        {
            _bookCRUD = bookCRUD;
            _library = library;
            _log = log;
        }
        public List<Book> ListBooks()
        {
            Books = (_bookCRUD.InitializeBook());
            _log.LogInformation($"Books in {_library.Name}:");
            foreach (var book in Books)
            {
                _log.LogInformation($"- {book.Title} by {book.Author} published in {book.YearPublished}, Is Available to Checkout: {book.IsAvailable}");
            }
            _log.LogInformation("\n |||||||||||||||||||||||||||||||||||||| \n");
            return Books;
        }
     
        public Book FindBookByTitle(string title)
        {
            foreach (var book in Books)
            {
                if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    return book;
                }
            }
            return null;
        }

        public List<Book> RemoveBooksByTitle(string title)
        {
            var book = FindBookByTitle(title);
            if (book != null)
            {
                Books.Remove(book);
            }
            return Books;
        }

        public List<Book> AddBooks(string title, string author, int pages, int yearPublished, bool isAvailable)
        {
            var book = new Book(title, author, pages, yearPublished, isAvailable);
            Books.Add(book);
            return Books;
        }

        public Book CheckoutBook(string title)
        {
            var book = FindBookByTitle(title);
            if (book != null && book.IsAvailable == true)
            {
                book.IsAvailable = false;
                _log.LogInformation($"{book.Title} is now checked out");
                return book;
            }
            else
            {
                _log.LogInformation($"{title} is not available.");
            }
            return null;
        }

        public Book ReturnBook(string title)
        {
            var book = FindBookByTitle(title);
            if (book != null && book.IsAvailable == false)
            {
                book.IsAvailable = true;
                _log.LogInformation($"{title} has been returned");
            }
            else
            {
                _log.LogInformation($"{title} is already in library");
            }
            return null;
        }

        public int TotalBooks()
        {
            int count = 0;
            foreach ( var book in Books )
            {
                if ( book.IsAvailable == true )
                {
                    count++;
                }
            }
            _log.LogInformation($"Number of books in library: {count}");
            return count;
        }
    }
}