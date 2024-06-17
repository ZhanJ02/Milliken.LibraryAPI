using System.Collections;
using Milliken.LibraryAPI.Models;
using Milliken.LibraryAPI.Interfaces;
using Microsoft.Extensions.Logging;

namespace Milliken.LibraryAPI.Services
{
    public class BookService : IBookService
    {
        private readonly Library _library;
        private readonly ILogger<BookService> _log;
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

       
        // Adding Books and EBooks
        public List<Book> AddBooks(string title, string author, int pages, int yearPublished)
        {
            var book = new Book(title, author, pages, yearPublished);
            Books.Add(book);
            return Books;
        }

       

        // Total Books and EBooks
        public int TotalBooks() => Books.Count;
    }

}