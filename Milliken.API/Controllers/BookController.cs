using Microsoft.AspNetCore.Mvc;
using Milliken.LibraryAPI.Interfaces;
using Milliken.LibraryAPI.Models;

namespace Milliken.LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService BookService)
        {
            bookService = BookService;
        }

        [HttpGet("Books in Library")]
        public List<Book> GetBooks()
        {
            return bookService.ListBooks();

        }

        [HttpDelete("Books in Library/{title}")]
        public List<Book> DeleteBook(string title)
        {
            bookService.RemoveBooksByTitle(title);
            return bookService.ListBooks();
        }

        [HttpPost("Add Books to Library")]
        public List<Book> AddBook(string author, string title, int pages, int yearPublished)
        {
            bookService.AddBooks(author, title, pages, yearPublished);
            return bookService.ListBooks();
        }

        [HttpGet("Total Books")]
        public int TotalNumberOfBooks()
        {
            return bookService.TotalBooks();
        }
    }
}