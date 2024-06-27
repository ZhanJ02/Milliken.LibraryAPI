namespace Milliken.LibrarySystem.CRUD
{
    public class SqlSettings
    {
        public DbSettings[]? DbSettings { get; set; }
    }

    public class DbSettings
    {
        public string? Name { get; set; }
        public string? ConnectionString { get; set; }
    }
}
