using Microsoft.AspNetCore.Mvc;
using Milliken.LibrarySystem.Core.Models;
using Milliken.LibrarySystem.Data.Interfaces;

namespace Milliken.LibrarySystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EBookController : ControllerBase
    {
        private readonly IEBookService _eBookService;

        public EBookController(IEBookService eBookService)
        {
            _eBookService = eBookService;
        }

        [HttpGet("EBooks in Library")]
        public List<EBook> GetEBooks()
        {
            return _eBookService.ListEBooks();
        }

        [HttpDelete("Deleting Ebooks by Title")]
        public List<EBook> DeleteEBook(string eTitle)
        {
            _eBookService.RemoveEBooksByTitle(eTitle);
            return _eBookService.ListEBooks();
        }

        [HttpPost("Add Electronic Books to Library")]
        public List<EBook> AddEBook(string author, string title, int pages, int yearPublished, double fileSize, bool isAvailable)
        {
            _eBookService.AddEBooks(author, title, pages, yearPublished, fileSize, isAvailable);
            return _eBookService.ListEBooks();
        }

        [HttpPost("Checkout EBooks from Library")]
        public EBook CheckoutEBook(string title)
        {
            return _eBookService.CheckoutEBook(title);
        }

        [HttpPost("Return EBooks to Library")]
        public Book ReturnBook(string title)
        {
            return _eBookService.ReturnEBook(title);
        }

        [HttpGet("Total EBooks")]
        public int TotalNumberOfEBooks()
        {
            return _eBookService.TotalEBooks();
        }
    }
}