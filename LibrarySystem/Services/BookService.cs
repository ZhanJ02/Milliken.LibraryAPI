using Milliken.LibrarySystem.Models;
using Milliken.LibrarySystem.Interfaces;
using Microsoft.Extensions.Logging;

namespace Milliken.LibrarySystem.Services
{
    public class BookService : IBookService
    {
        private readonly Library _library;
        private readonly ILogger<BookService> _log;
        private readonly Random _random = new Random();
        private readonly List<Book> AllBooks = new List<Book>()
        {
             new("Harry Potter and the Goblet of Fire", "J.K. Rowling", 550, 2000, true),
             new("To Kill a Mockingbird", "Harper Lee", 320, 1960, true),
             new("1984", "George Orwell", 398, 1949, false),
             new("The Stranger", "Albert Camus", 320, 1942, false),
             new("Harry Potter and the Sorcerer's Stone", "J.K. Rowling", 311, 1997, true),
             new("The Hobbit", "J. R. R. Tolkien", 346, 1937, true),
             new("The Lightning Thief", "Rick Riordan", 380, 2005, false),
             new("The Martian", "Andy Weir", 450, 2011, false),
             new("Precious", "Sapphire", 241, 1996, true),
             new("Beloved", "Toni Morrison", 289, 1987, true)
        };
      
        public List<Book> Books { get; set; } = new List<Book>();
        // Constructor DI
        public BookService(Library library, ILogger<BookService> log)
        {
            _library = library;
            _log = log;
            InitializeBookData();
        }

        public void InitializeBookData()
        {
            for (int i = 0; i < 5; i++)
            {
                int randomIndex = _random.Next(0, AllBooks.Count);
                Book selectedBook = AllBooks[randomIndex];
                Books.Add(selectedBook);
                AllBooks.Remove(selectedBook);
            }
        }
       
        public List<Book> ListBooks()
        {
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