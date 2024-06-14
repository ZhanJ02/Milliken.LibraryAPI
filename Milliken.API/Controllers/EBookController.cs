using Microsoft.AspNetCore.Mvc;
using Milliken.LibraryAPI.Interfaces;
using Milliken.LibraryAPI.Models;

namespace Milliken.LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EBookController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public EBookController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet("EBooks in Library")]
        [Route("get_ebooks")]
        public List<EBook> GetEBooks()
        {
            return _libraryService.ListEBooks();
        }
        
        /*
        [HttpGet("Total Books and EBooks")]
        public int TotalNumberOfAllBooks()
        {
            return _libraryService.TotalBooksAndEBooks();
        }
        */

        [HttpDelete("EBooks in Library/{eTitle}")]
        [Route("remove_ebooks")]
        public List<EBook> DeleteEBook(string eTitle)
        {
            _libraryService.RemoveEBooksByTitle(eTitle);
            return _libraryService.ListEBooks();
        }

        [HttpPost("Add Electronic Books to Library")]
        [Route("create_ebooks")]
        public List<EBook> AddEBook(string author, string title, int pages, int yearPublished, double fileSize)
        {
            _libraryService.AddEBooks(author, title, pages, yearPublished, fileSize);
            return _libraryService.ListEBooks();
        }

    }
}