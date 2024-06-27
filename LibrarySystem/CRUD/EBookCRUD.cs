using Microsoft.Extensions.Options;
using Milliken.LibrarySystem.Models;
using System.Data.SqlClient;
using Dapper;

namespace Milliken.LibrarySystem.CRUD
{
    public class EBookCRUD
    {
        private readonly IOptions<SqlSettings> _sqlOptions;
        private readonly string? _connectionString;
        public List<EBook> Ebooks { get; set; } = new List<EBook>();
        // Constructor DI
        public EBookCRUD(IOptions<SqlSettings> sqlOptions)
        {
            _sqlOptions = sqlOptions;
            _connectionString = _sqlOptions.Value?.DbSettings?
                .SingleOrDefault(name => name.Name == "libraryDb")?.ConnectionString;
        }

        public List<EBook> CreateEBook()
        {
            using var connection = new SqlConnection(_connectionString);
            string sqlQuery = "select Title, Author, Pages, YearPublished, IsAvailable, FileSize, IsElectronic from Book;";
            var tableData = connection.Query(sqlQuery);
            foreach (var row in tableData)
            {
                var eBook = new EBook(row.Title, row.Author, row.Pages, int.Parse(row.YearPublished.ToString("yyyy")), row.FileSize, false);
                if (Convert.ToInt16(row.IsAvailable) == 0)
                {
                    eBook.IsAvailable = false;
                }
                else if (Convert.ToInt16(row.IsAvailable) == 1)
                {
                    eBook.IsAvailable = true;
                }
                Ebooks.Add(eBook);
                if (Convert.ToInt16(row.IsElectronic) == 0)
                {
                    Ebooks.Remove(eBook);
                }
            }
            return Ebooks;
        }
    }
}
