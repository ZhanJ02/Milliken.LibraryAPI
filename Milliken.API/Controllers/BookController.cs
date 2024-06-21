using Microsoft.AspNetCore.Mvc;
using Milliken.LibrarySystem.Interfaces;
using Milliken.LibrarySystem.Models;

namespace Milliken.LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService BookService)
        { 
            _bookService = BookService;
        }

        [HttpGet("Books in Library")]
        public List<Book> GetBooks()
        {
            return _bookService.ListBooks();
        }

        [HttpDelete("Deleting Books in Library")]
        public List<Book> DeleteBook(string title)
        {
            _bookService.RemoveBooksByTitle(title);
            return _bookService.ListBooks();
        }

        [HttpPost("Add Books to Library")]
        public List<Book> AddBook(string author, string title, int pages, int yearPublished, bool isAvailable)
        {
            _bookService.AddBooks(author, title, pages, yearPublished, isAvailable);
            return _bookService.ListBooks();
        }

        [HttpPost("Checkout Books from Library")]
        public Book CheckoutBook(string title)
        {
            return _bookService.CheckoutBook(title);
        }

        [HttpPost("Return Books to Library")]
        public Book ReturnBook(string title)
        {
            return _bookService.ReturnBook(title);
        }

        [HttpGet("Total Books")]
        public int TotalNumberOfBooks()
        {
            return _bookService.TotalBooks();
        }
    }
}