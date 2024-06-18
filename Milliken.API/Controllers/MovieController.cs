using Microsoft.AspNetCore.Mvc;
using Milliken.LibrarySystem.Interfaces;
using Milliken.LibrarySystem.Models;

namespace Milliken.LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("Movies in Library")]
        public List<Movie> GetEmployees()
        {
            return _movieService.ListMovies();
        }

        [HttpDelete("Deleting Movies by Name")]
        public List<Movie> DeleteEmployees(string name)
        {
            _movieService.RemoveMovieByName(name);
            return _movieService.ListMovies();
        }

        [HttpPost("Add Movies to Library")]
        public List<Movie> AddEmployees(string name, GenresOfMovies genre, int durationInMinutes, bool isAvailable)
        {
            _movieService.AddMovies(name, genre, durationInMinutes, isAvailable);
            return _movieService.ListMovies();
        }

        [HttpPost("List All Movies by Genre")]
        public List<Movie> ListAllEmployeesByPosition(GenresOfMovies genre)
        {
            return _movieService.ListAllMoviesByGenre(genre);
        }

        [HttpPost("Checkout Movies from Library")]
        public Movie CheckoutMovie(string name)
        {
            return _movieService.CheckoutMovie(name);
        }

        [HttpPost("Return Movies to Library")]
        public Movie ReturnMovie(string name)
        {
            return _movieService.ReturnMovie(name);
        }

        [HttpGet("Total Movies")]
        public int TotalEmployees()
        {
            return _movieService.TotalMovies();
        }

    }
}