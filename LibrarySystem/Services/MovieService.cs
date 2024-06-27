using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Milliken.LibrarySystem.Interfaces;
using Milliken.LibrarySystem.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace Milliken.LibrarySystem.Services
{
    public class MovieService : IMovieService
    {
        private readonly Library _library;
        private readonly ILogger<MovieService> _log;
        private readonly IOptions<SqlSettings> _sqlOptions;
        private readonly string? _connectionString;
        public List<Movie> Movies { get; set; } = new List<Movie>();
        // Constructor DI
        public MovieService(IOptions<SqlSettings> sqlOptions, ILogger<MovieService> log, Library library)
        {
            _sqlOptions = sqlOptions;
            _connectionString = _sqlOptions.Value?.DbSettings?
                .SingleOrDefault(name => name.Name == "MesDb")?.ConnectionString;
            _library = library;
            _log = log;
        }

        public List<Movie> ListMovies()
        {
            using var connection = new SqlConnection(_connectionString);
            string sqlQuery = "SELECT * FROM sys.tables";

            // Fetch Movies from Database
            List<Movie> results = connection.Query<Movie>(sqlQuery).ToList();

            _log.LogInformation($"Movies in {_library.Name}:");
            foreach (var movie in results)
            {
                _log.LogInformation($"- {movie.Name}: Genre: {movie.Genre}, Duration in Minutes: {movie.DurationInMinutes}, Is Available to Checkout: {movie.IsAvailable}");
            }
            _log.LogInformation("\n -------------------------------------- \n");

            return results;
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