using Microsoft.Extensions.Options;
using Milliken.LibrarySystem.Core.Models;
using System.Data.SqlClient;
using Dapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Milliken.LibrarySystem.Data.CRUD
{
    public class BookCRUD
    {
        private readonly IOptions<SqlSettings> _sqlOptions;
        private readonly string? _connectionString;
        public List<Book> Books { get; set; } = new List<Book>();
        // Constructor DI
        public BookCRUD(IOptions<SqlSettings> sqlOptions)
        {
            _sqlOptions = sqlOptions;
            _connectionString = _sqlOptions.Value?.DbSettings?
                .SingleOrDefault(name => name.Name == "libraryDb")?.ConnectionString;
        }

        public List<Book> InitializeBook()
        {
            using var connection = new SqlConnection(_connectionString);
            string sqlQuery = "select Title, Author, Pages, YearPublished, IsAvailable, IsElectronic from Book;";
            var tableData = connection.Query(sqlQuery);
            foreach (var row in tableData)
            {
                var book = new Book(row.Title, row.Author, row.Pages, int.Parse(row.YearPublished.ToString("yyyy")), false);
                if (Convert.ToInt16(row.IsAvailable) == 0)
                {
                    book.IsAvailable = false;
                }
                else
                {
                    book.IsAvailable = true;
                }
                Books.Add(book);
                if (Convert.ToInt16(row.IsElectronic) == 1)
                {
                    Books.Remove(book);
                }
            }
            return Books;
        }
    }
}
