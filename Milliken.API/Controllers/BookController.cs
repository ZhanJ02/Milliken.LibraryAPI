using Microsoft.AspNetCore.Mvc;
using Milliken.LibraryAPI.Interfaces;
using Milliken.LibraryAPI.Models;

namespace Milliken.LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _libraryService;

        public BookController(IBookService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet("Books in Library")]
        public List<Book> GetBooks()
        {
            return _libraryService.ListBooks();

        }

        [HttpDelete("Books in Library/{title}")]
        public List<Book> DeleteBook(string title)
        {
            _libraryService.RemoveBooksByTitle(title);
            return _libraryService.ListBooks();
        }

        [HttpPost("Add Books to Library")]
        public List<Book> AddBook(string author, string title, int pages, int yearPublished)
        {
            _libraryService.AddBooks(author, title, pages, yearPublished);
            return _libraryService.ListBooks();
        }

        [HttpGet("Total Books")]
        public int TotalNumberOfBooks()
        {
            return _libraryService.TotalBooks();
        }
    }
}