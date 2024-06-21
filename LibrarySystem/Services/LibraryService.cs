using Milliken.LibrarySystem.Models;
using Milliken.LibrarySystem.Interfaces;
using Microsoft.Extensions.Logging;

namespace Milliken.LibrarySystem.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ILogger<LibraryService> _log;
        private readonly Library _library;
        private readonly Random _random = new Random();
        public List<Library> Libraries { get; set; } = new List<Library>();

        // Constructor DI
        public LibraryService(Library library, ILogger<LibraryService> log)
        {
            _library = library;
            _log = log;
        }

        private readonly List<Library> AllLibraries = new List<Library>()
        {
             new("Milliken Library", "Spartanburg"),
             new("Anderson Library", "Spartanburg"),
             new("Greenville Library", "Greenville"),
             new("Upstate Library", "Spartanburg"),
             new("Thomcas Cooper Library", "Columbia"),
             new("Florence Library", "Florence")
        };
        public List<Library> CreateLibraries()
        {
            for (int i = 0; i < 3; i++)
            {
                int randomIndex = _random.Next(0, AllLibraries.Count);
                Library selectedLibrary = AllLibraries[randomIndex];
                Libraries.Add(selectedLibrary);
                Libraries.Remove(selectedLibrary);
            }
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
