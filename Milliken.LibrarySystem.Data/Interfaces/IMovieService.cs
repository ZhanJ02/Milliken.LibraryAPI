using Milliken.LibrarySystem.Core.Models;

namespace Milliken.LibrarySystem.Data.Interfaces
{
    public interface IMovieService
    {
        List<Movie> ListMovies();
        Movie FindMovieByName(string name);
        List<Movie> RemoveMovieByName(string name);
        List<Movie> AddMovies(string name, GenresOfMovies genre, int durationInMinutes, bool isAvailable);
        List<Movie> ListAllMoviesByGenre(GenresOfMovies genre);
        Movie CheckoutMovie(string name);
        Movie ReturnMovie(string name);
        int TotalMovies();
    }
}
