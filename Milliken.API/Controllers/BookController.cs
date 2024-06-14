using Microsoft.AspNetCore.Mvc;
using Milliken.LibraryAPI.Interfaces;
using Milliken.LibraryAPI.Models;

namespace Milliken.LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public BookController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet("Books in Library")]
        [Route("get_books")]
        public List<Book> GetBooks()
        {
            return _libraryService.ListBooks();

        }

        [HttpDelete("Books in Library/{title}")]
        [Route("remove_books")]

        public List<Book> DeleteBook(string title)
        {
            _libraryService.RemoveBooksByTitle(title);
            return _libraryService.ListBooks();
        }

        [HttpPost("Add Books to Library")]
        [Route("create_books")]
        public List<Book> AddBook(string author, string title, int pages, int yearPublished)
        {
            _libraryService.AddBooks(author, title, pages, yearPublished);
            return _libraryService.ListBooks();
        }
    }
}