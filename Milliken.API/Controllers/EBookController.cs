using Microsoft.AspNetCore.Mvc;
using Milliken.LibraryAPI.Interfaces;
using Milliken.LibraryAPI.Models;

namespace Milliken.LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EBookController : ControllerBase
    {
        private readonly IEBookService _libraryService;

        public EBookController(IEBookService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet("EBooks in Library")]
        public List<EBook> GetEBooks()
        {
            return _libraryService.ListEBooks();
        }

        [HttpDelete("EBooks in Library/{eTitle}")]
        public List<EBook> DeleteEBook(string eTitle)
        {
            _libraryService.RemoveEBooksByTitle(eTitle);
            return _libraryService.ListEBooks();
        }

        [HttpPost("Add Electronic Books to Library")]
        public List<EBook> AddEBook(string author, string title, int pages, int yearPublished, double fileSize)
        {
            _libraryService.AddEBooks(author, title, pages, yearPublished, fileSize);
            return _libraryService.ListEBooks();
        }

        [HttpGet("Total EBooks")]
        public int TotalNumberOfEBooks()
        {
            return _libraryService.TotalEBooks();
        }

    }
}