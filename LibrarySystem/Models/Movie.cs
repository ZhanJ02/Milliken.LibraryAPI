namespace Milliken.LibrarySystem.Core.Models
{
    public enum GenresOfMovies
    {
        Action,
        Horror,
        Romance,
        Drama,
        Comedy,
        Adventure
    }
    public class Movie
    {
        // Properties
        public string Name { get; set; }
        public GenresOfMovies Genre { get; set; }
        public int DurationInMinutes { get; set; }
        public bool IsAvailable { get; set; }
        // Parameterized Constructor
        public Movie(string name, GenresOfMovies genre, int durationInMinutes, bool isAvailable)
        {
            Name = name;
            Genre = genre;
            DurationInMinutes = durationInMinutes;
            IsAvailable = isAvailable;
        }
    }
}
