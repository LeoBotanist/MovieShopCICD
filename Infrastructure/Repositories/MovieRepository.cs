using System.Diagnostics.CodeAnalysis;
using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models.ResponseModels;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MovieRepository(MovieShopDbContext movieShopDbContext) : BaseRepository<Movie>(movieShopDbContext), IMovieRepository
{
    
    public Movie? GetHighestGrossingMovie()
    {
       return _movieShopDbContext.Set<Movie>().ToList().MinBy(m => m.Revenue);
    }
    
    
    public void PrintCasts()
    {
        var movies = _movieShopDbContext.Movies
            .Include(m => m.MovieGenres)
            .ThenInclude(mv => mv.Genre)
            .ToList();
        foreach (var movie in movies)
        {
            Console.WriteLine($"Movie: {movie.Title}");
            foreach (var movieGenre in movie.MovieGenres)
            {
                Console.WriteLine($"    -Genre: {movieGenre.Genre.Name}");
            }
        }
    }

    public Movie GetMovieDetailsById(int id)
    {
        var model = _movieShopDbContext.Set<Movie>()
            .Include(m => m.MovieGenres)
            .ThenInclude(mg => mg.Genre)
            .Include(m => m.MovieCasts)
            .ThenInclude(mc => mc.Cast)
            .Include(m => m.Reviews)
            .Include(m => m.Purchases)
            .Include(m => m.Trailers)
            .FirstOrDefault(m => m.Id == id);
        return model;
    }

    public IEnumerable<Movie> GetMoviePaging(int pageNumber, int pageSize)
    {
        return _movieShopDbContext.Set<Movie>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public IEnumerable<Movie> GetMoviesByGenre(int pageNumber, int pageSize, int genreId)
    {
        return _movieShopDbContext.Set<Movie>()
            .Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId))
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }
}