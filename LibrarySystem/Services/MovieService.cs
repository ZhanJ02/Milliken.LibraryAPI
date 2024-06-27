using Microsoft.Extensions.Logging;
using Milliken.LibrarySystem.Interfaces;
using Milliken.LibrarySystem.Models;
using Milliken.LibrarySystem.CRUD;

namespace Milliken.LibrarySystem.Services
{
    public class MovieService : IMovieService
    {
        private readonly Library _library;
        private readonly MovieCRUD _movieCRUD;
        private readonly ILogger<MovieService> _log;
        public List<Movie> Movies { get; set; } = new List<Movie>();
        // Constructor DI
        public MovieService(ILogger<MovieService> log, Library library, MovieCRUD movieCRUD)
        {
            _movieCRUD = movieCRUD;
            _library = library;
            _log = log;
        }

        public List<Movie> ListMovies()
        {
            Movies = (_movieCRUD.CreateMovie());
            return Movies;
        }

        public Movie FindMovieByName(string name)
        {
            foreach (var movie in Movies)
            {
                if (movie.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return movie;
                }
            }
            return null;
        }

        public List<Movie> RemoveMovieByName(string name)
        {
            var movie = FindMovieByName(name);
            if (movie != null)
            {
                Movies.Remove(movie);
            }
            return Movies;
        }

        public List<Movie> AddMovies(string name, GenresOfMovies genre, int durationInMinutes, bool isAvailable)
        {
            var movie = new Movie(name, genre, durationInMinutes, isAvailable);
            Movies.Add(movie);
            return Movies;
        }

        public List<Movie> ListAllMoviesByGenre(GenresOfMovies genre)
        {
            List<Movie> sameGenre = new List<Movie>();
            _log.LogInformation($"{genre}s");
            foreach (var movie in Movies)
            {
                if (movie.Genre == genre)
                {
                    _log.LogInformation($"-{movie.Name}");
                    sameGenre.Add(movie);
                }
            }
            return sameGenre;
        }

        public Movie CheckoutMovie(string name)
        {
            var movie = FindMovieByName(name);
            if (movie != null && movie.IsAvailable == true)
            {
                movie.IsAvailable = false;
                _log.LogInformation($"{movie.Name} is now checked out");
                return movie;
            }
            else
            {
                _log.LogInformation($"{name} is not available.");
            }
            return null;
        }

        public Movie ReturnMovie(string name)
        {
            var movie = FindMovieByName(name);
            if (movie != null && movie.IsAvailable == false)
            {
                movie.IsAvailable = true;
                _log.LogInformation($"{name} has been returned");
            }
            else
            {
                _log.LogInformation($"{name} is already in library");
            }
            return null;
        }

        public int TotalMovies()
        {
            int count = 0;
            foreach (var movie in Movies)
            {
                if (movie.IsAvailable == true)
                {
                    count++;
                }
            }
            _log.LogInformation($"Number of available movies in library: {count}");
            return count;
        }
    }
}