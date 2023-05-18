namespace MoviesApi.Main.Api.Services;

using MongoDB.Bson;
using Domain.Models;
using Dtos.Filter;

/// <summary>
/// Interface for the Movie Service which provides methods for retrieving, creating, updating and deleting movies.
/// </summary>
public interface IMovieService
{
    /// <summary>
    /// Retrieves a list of movies that match the specified filter criteria and returns a paginated result.
    /// </summary>
    /// <param name="filter">A MovieFilter object containing the filter criteria.</param>
    /// <returns>A paginated list of movies that match the specified filter criteria.</returns>
    Task<List<Movie>> List(MovieFilter filter);

    /// <summary>
    /// Retrieves the movie with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the movie to retrieve.</param>
    /// <returns>The movie with the specified ID, or null if the movie does not exist.</returns>
    Task<Movie?> Get(ObjectId id);

    /// <summary>
    /// Creates a new movie.
    /// </summary>
    /// <param name="movie">The Movie object containing the data for the new movie.</param>
    /// <returns>The newly created movie.</returns>
    Task<Movie> Create(Movie movie);

    /// <summary>
    /// Updates the movie with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the movie to update.</param>
    /// <param name="updatedMovie">The updated Movie object containing the updated data for the movie.</param>
    /// <returns>The updated movie, or null if the movie does not exist.</returns>
    Task<Movie?> Update(ObjectId id, Movie updatedMovie);

    /// <summary>
    /// Deletes the movie with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the movie to delete.</param>
    Task<ObjectId?> Delete(ObjectId id);
}
