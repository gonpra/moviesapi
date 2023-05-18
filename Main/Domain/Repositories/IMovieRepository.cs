using MoviesApi.Main.Api.Dtos.Filter;
using MoviesApi.Main.Domain.Models;

namespace MoviesApi.Main.Domain.Repositories;

/// <summary>
/// An interface representing a movie repository that inherits from the generic repository of type Movie.
/// </summary>
public interface IMovieRepository : IGenericRepository<Movie>
{
    /// <summary>
    /// Retrieves a paginated list of all movies.
    /// </summary>
    /// <returns>A Pagination object containing a list of movies and pagination metadata.</returns>
    Task<List<Movie>> Search(MovieFilter filter);
}