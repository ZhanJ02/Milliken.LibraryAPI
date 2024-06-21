using Milliken.LibrarySystem.Models;
using Milliken.LibrarySystem.Interfaces;
using Microsoft.Extensions.Logging;

namespace Milliken.LibrarySystem.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ILogger<LibraryService> _log;
        private readonly Library _library;
        public List<Library> Libraries { get; set; } = new List<Library>();

        // Constructor DI
        public LibraryService(Library library, ILogger<LibraryService> log)
        {
            _library = library;
            _log = log;
        }

        public List<Library> CreateLibraries()
        {
            
            return Libraries;
        }

        public List<Library> ReadLibraries()
        {
            return Libraries;
        }

        public List<Library> UpdateLibraries()
        {
            return Libraries;
        }

        public List<Library> DeleteLibraries()
        {
            return Libraries;
        }
    }
}
