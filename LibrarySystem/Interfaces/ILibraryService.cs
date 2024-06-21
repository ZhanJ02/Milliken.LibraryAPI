using Milliken.LibrarySystem.Models;

namespace Milliken.LibrarySystem.Interfaces
{ 
    public interface ILibraryService
    {
        List<Library> CreateLibraries();
        List<Library> ReadLibraries();
        List<Library> UpdateLibraries();
        List<Library> DeleteLibraries();
    }
}
