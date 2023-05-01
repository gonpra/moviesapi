using Microsoft.EntityFrameworkCore;
using MoviesApi.Main.Api.Dtos.Filter;
using MoviesApi.Main.Core.Database;
using MoviesApi.Main.Core.Pagination;
using MoviesApi.Main.Domain.Models;

namespace MoviesApi.Main.Domain.Repositories.Implementation;

/// <summary>
/// A class that represents a movie repository and inherits from the generic repository of type Movie. Implements the IMovieRepository interface.
/// </summary>
public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    private readonly DataContext _context;

    /// <summary>
    /// Constructor for the MovieRepository class that initializes a new instance of the class with the specified DataContext.
    /// </summary>
    /// <param name="context">The DataContext object to use for database operations.</param>
    public MovieRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves a paginated list of all movies.
    /// </summary>
    /// <returns>A Pagination object containing a list of movies and pagination metadata.</returns>
    public async Task<List<Movie>> Search(MovieFilter filter)
    {
        return await _context.Movies
            .Where(movie =>
                (filter.Title ?? movie.Title) == movie.Title
                && (filter.Genre ?? movie.Genre) == movie.Genre
                && (filter.Duration ?? movie.Duration) == movie.Duration
            )
            .ToListAsync();
    }
}
