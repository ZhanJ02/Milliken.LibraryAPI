using Microsoft.AspNetCore.Mvc;
using Milliken.LibraryAPI.Interfaces;
using Milliken.LibraryAPI.Models;

namespace Milliken.LibraryAPI.Controllers
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

        [HttpDelete("EBooks in Library/{eTitle}")]
        public List<EBook> DeleteEBook(string eTitle)
        {
            _eBookService.RemoveEBooksByTitle(eTitle);
            return _eBookService.ListEBooks();
        }

        [HttpPost("Add Electronic Books to Library")]
        public List<EBook> AddEBook(string author, string title, int pages, int yearPublished, double fileSize)
        {
            _eBookService.AddEBooks(author, title, pages, yearPublished, fileSize);
            return _eBookService.ListEBooks();
        }

        [HttpGet("Total EBooks")]
        public int TotalNumberOfEBooks()
        {
            return _eBookService.TotalEBooks();
        }

    }
}