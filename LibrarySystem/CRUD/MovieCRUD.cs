using Microsoft.Extensions.Options;
using Milliken.LibrarySystem.Models;
using System.Data.SqlClient;
using Dapper;

namespace Milliken.LibrarySystem.CRUD
{
    public class MovieCRUD
    {
        private readonly IOptions<SqlSettings> _sqlOptions;
        private readonly string? _connectionString;
        public List<Movie> Movies { get; set; } = new List<Movie>();
        // Constructor DI
        public MovieCRUD(IOptions<SqlSettings> sqlOptions)
        {
            _sqlOptions = sqlOptions;
            _connectionString = _sqlOptions.Value?.DbSettings?
                .SingleOrDefault(name => name.Name == "libraryDb")?.ConnectionString;
        }

        public List<Movie> CreateMovie()
        {
            using var connection = new SqlConnection(_connectionString);
            string sqlQuery = "select Name, Genre, DurationInMinutes, IsAvailable from Movie;";
            var tableData = connection.Query(sqlQuery);
            foreach (var row in tableData)
            {
                var movie = new Movie(row.Name, GenresOfMovies.Action, row.DurationInMinutes, false);               
                if (row.Genre == 1)
                {
                    movie.Genre = GenresOfMovies.Horror;
                }
                else if (row.Genre == 2)
                {
                    movie.Genre = GenresOfMovies.Romance;
                }
                else if (row.Genre == 3)
                {
                    movie.Genre = GenresOfMovies.Drama;
                }
                else if (row.Genre == 4)
                {
                    movie.Genre = GenresOfMovies.Comedy;
                }
                else if (row.Genre == 5)
                {
                    movie.Genre = GenresOfMovies.Adventure;
                }
                if (Convert.ToInt16(row.IsAvailable) == 0)
                {
                    movie.IsAvailable = false;
                }
                else if (Convert.ToInt16(row.IsAvailable) == 1)
                {
                    movie.IsAvailable = true;
                }
                Movies.Add(movie);
            }
            return Movies;
        }
    }
}
