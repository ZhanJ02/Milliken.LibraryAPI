﻿using Microsoft.Extensions.Logging;
using Milliken.LibrarySystem.Interfaces;
using Milliken.LibrarySystem.Models;

namespace Milliken.LibrarySystem.Services
{
    public class MovieService : IMovieService
    {
        private readonly Library _library;
        private readonly ILogger<MovieService> _log;
        private readonly Random _random = new Random();
        public List<Movie> Movies { get; set; } = new List<Movie>();
        private readonly List<Movie> AllMovies = new List<Movie>()
        {
             new("Monkey Man", GenresOfMovies.Action, 113, true),
             new("Megamind", GenresOfMovies.Action, 85, true),
             new("Dune: Part One", GenresOfMovies.Adventure, 155, true),
             new("Lord of the Rings: The Fellowship of the Ring", GenresOfMovies.Adventure, 208, false),
             new("Star Wars: Episode 3 - Revenge of the Sith", GenresOfMovies.Action, 140, false),
             new("Anyone But You", GenresOfMovies.Romance, 103, false),
             new("The Notebook", GenresOfMovies.Romance, 121, true),
             new("Fall Guy", GenresOfMovies.Comedy, 145, true),
             new("Office Space", GenresOfMovies.Comedy, 99, true),
             new("Challengers", GenresOfMovies.Drama, 131, false),
             new("Spaceman",GenresOfMovies.Drama ,109, true)
        };
        // Constructor DI
        public MovieService(Library library, ILogger<MovieService> log)
        {
            _library = library;
            _log = log;
            InitializeMovieData();
        }

        public void InitializeMovieData()
        {
            for (int i = 0; i < 7; i++)
            {
                int randomIndex = _random.Next(0, AllMovies.Count);
                Movie selectedMovie = AllMovies[randomIndex];
                Movies.Add(selectedMovie);
                AllMovies.Remove(selectedMovie);
            }
        }
        // List EBooks
        public List<Movie> ListMovies()
        {
            _log.LogInformation($"Movies in {_library.Name}:");
            foreach (var movie in Movies)
            {
                _log.LogInformation($"- {movie.Name}: Genre: {movie.Genre}, Duration in Minutes: {movie.DurationInMinutes}");
            }
            _log.LogInformation("\n -------------------------------------- \n");
            return Movies;
        }

        // Find EBook
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
        // Adding EBooks
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
        public int TotalMovies()
        {
            _log.LogInformation($"Number of movies in library: {Movies.Count}");
            return Movies.Count;
        }
    }
}