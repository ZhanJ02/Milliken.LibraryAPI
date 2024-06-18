﻿using Milliken.LibrarySystem.Models;

namespace Milliken.LibrarySystem.Interfaces
{
    public interface IMovieService
    {
        void InitializeMovieData();
        List<Movie> ListMovies();
        Movie FindMovieByName(string name);
        List<Movie> RemoveMovieByName(string name);
        List<Movie> AddMovies(string name, GenresOfMovies genre, int durationInMinutes, bool isAvailable);
        List<Movie> ListAllMoviesByGenre(GenresOfMovies genre);
        int TotalMovies();
    }
}