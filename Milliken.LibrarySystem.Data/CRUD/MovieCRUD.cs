using Microsoft.Extensions.Options;
using Milliken.LibrarySystem.Core.Models;
using System.Data.SqlClient;
using Dapper;

namespace Milliken.LibrarySystem.Data.CRUD
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

        public List<Movie> InitializeMovie()
        {
            using var connection = new SqlConnection(_connectionString);
            string sqlQuery = "select Name, Genre, DurationInMinutes, IsAvailable from Movie;";
            var tableData = connection.Query(sqlQuery);
            foreach (var row in tableData)
            {
                var movie = new Movie(row.Name, GenresOfMovies.Action, row.DurationInMinutes, false);
                switch (row.Genre)
                {
                    case 0:
                        movie.Genre = GenresOfMovies.Action;
                        break;
                    case 1:
                        movie.Genre = GenresOfMovies.Horror;
                        break;
                    case 2:
                        movie.Genre = GenresOfMovies.Romance;
                        break;
                    case 3:
                        movie.Genre = GenresOfMovies.Drama;
                        break;
                    case 4:
                        movie.Genre = GenresOfMovies.Comedy;
                        break;
                    case 5:
                        movie.Genre = GenresOfMovies.Adventure;
                        break;
                }
                if (Convert.ToInt16(row.IsAvailable) == 0)
                {
                    movie.IsAvailable = false;
                }
                else
                {
                    movie.IsAvailable = true;
                }
                Movies.Add(movie);
            }
            return Movies;
        }
    }
}
