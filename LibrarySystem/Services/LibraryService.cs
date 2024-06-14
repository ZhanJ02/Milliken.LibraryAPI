using System.Collections;
using Milliken.LibraryAPI.Models;
using Milliken.LibraryAPI.Interfaces;
using Microsoft.Extensions.Logging;

namespace Milliken.LibraryAPI.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly Library _library;
        private readonly ILogger<LibraryService> _log;
        public List<Book> Books { get; set; } = new List<Book>();
        public List<EBook> EBooks { get; set; } = new List<EBook>();
        // Constructor DI
        public LibraryService(Library library, ILogger<LibraryService> log)
        {
            _library = library;
            _log = log;

            InitializeBookData();
            InitializeEBookData();
        }
        public void InitializeBookData()
        {
            // Create Books
            Book book1 = new("Harry Potter and the Goblet of Fire", "J.K. Rowling", 550, 2000);
            Book book2 = new("To Kill a Mockingbird", "Harper Lee", 320, 1960);
            Book book3 = new("1984", "George Orwell", 398, 1949);
            Book book4 = new("The Stranger", "Albert Camus", 320, 1942);
            Book book5 = new("Harry Potter and the Sorcerer's Stone", "J.K. Rowling", 311, 1997);

            Books.Add(book1);
            Books.Add(book2);
            Books.Add(book3);
            Books.Add(book4);
            Books.Add(book5);
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
        // List Books
        public List<Book> ListBooks()
        {
            _log.LogInformation($"Books in {_library.Name}:");
            foreach (var book in Books)
            {
                _log.LogInformation($"- {book.Title} by {book.Author} published in {book.YearPublished}");
            }
            _log.LogInformation("\n |||||||||||||||||||||||||||||||||||||| \n");
            return Books;
        }
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
        // Find Book
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

        // Remove Book
        public List<Book> RemoveBooksByTitle(string title)
        {
            var book = FindBookByTitle(title);
            if (book != null)
            {
                Books.Remove(book);
            }
            return Books;
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
        // Adding Books and EBooks
        public List<Book> AddBooks(string title, string author, int pages, int yearPublished)
        {
            var book = new Book(title, author, pages, yearPublished);
            Books.Add(book);
            return Books;
        }

        public List<EBook> AddEBooks(string title, string author, int pages, int yearPublished, double fileSize)
        {
            var eBook = new EBook(title, author, pages, yearPublished, fileSize);
            EBooks.Add(eBook);
            return EBooks;
        }

        // Total Books and EBooks
        public int TotalBooksAndEBooks() => EBooks.Count + Books.Count;
    }

}