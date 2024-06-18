/*
using Milliken.LibrarySystem.Models;
using Milliken.LibrarySystem.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;

namespace Milliken.LibraryAPI.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly Library _library;
        private readonly ILogger<BookService> _log;
        private readonly Random _random = new Random();
        private readonly List<Library> AllLibraries = new List<Library>()
        {
             new("Milliken Library", "Spartanburg"),
             new("Converse Library", "Spartanburg"),
             new("UofSC Upstate Library", "Spartanburg"),
             new("Anderson Library", "Spartanburg"),
             new("Greenville Library", "Greenville"),
        };

        public List<Library> Libraries { get; set; } = new List<Library>();
        // Constructor DI
        public LibraryService(Library library, ILogger<BookService> log)
        {
            _library = library;
            _log = log;
            InitializeLibraryData();
        }
        public void InitializeLibraryData()
        {
            for (int i = 0; i < 3; i++)
            {
                int randomIndex = _random.Next(0, AllLibraries.Count);
                Library selectedLibraries = AllLibraries[randomIndex];
                Libraries.Add(selectedLibraries);
                AllLibraries.Remove(selectedLibraries);
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
*/