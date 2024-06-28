using Milliken.LibrarySystem.Core.Models;

namespace Milliken.LibrarySystem.Data.Interfaces
{
    public interface ILibraryService
    {
        List<Library> CreateLibraries();
        List<Library> ReadLibraries();
        List<Library> UpdateLibraries();
        List<Library> DeleteLibraries();
    }
}
