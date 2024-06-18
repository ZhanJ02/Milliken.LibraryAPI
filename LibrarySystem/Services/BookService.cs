using System.Collections;
using Milliken.LibraryAPI.Models;
using Milliken.LibraryAPI.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;

namespace Milliken.LibraryAPI.Services
{
    public class BookService : IBookService
    {
        private readonly Library _library;
        private readonly ILogger<BookService> _log;
        private readonly Random _random = new Random();
        private readonly List<Book> AllBooks = new List<Book>()
        {
             new("Harry Potter and the Goblet of Fire", "J.K. Rowling", 550, 2000),
             new("To Kill a Mockingbird", "Harper Lee", 320, 1960),
             new("1984", "George Orwell", 398, 1949),
             new("The Stranger", "Albert Camus", 320, 1942),
             new("Harry Potter and the Sorcerer's Stone", "J.K. Rowling", 311, 1997),
             new("The Hobbit", "J. R. R. Tolkien", 346, 1937),
             new("The Lightning Thief", "Rick Riordan", 380, 2005),
             new("The Martian", "Andy Weir", 450, 2011),
             new("Precious", "Sapphire", 241, 1996),
             new("Beloved", "Toni Morrison", 289, 1987)
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



        // Total Books
        public int TotalBooks()
        {
            _log.LogInformation($"Number of books in library: {Books.Count}");
            return Books.Count;
        }

    }

}