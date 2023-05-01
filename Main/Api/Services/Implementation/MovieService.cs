using MoviesApi.Main.Api.Dtos.Filter;
using MoviesApi.Main.Core.Pagination;
using MoviesApi.Main.Domain.Models;
using MoviesApi.Main.Domain.Repositories;

namespace MoviesApi.Main.Api.Services.Implementation;

/// <summary>
/// Service class for managing Movies.
/// </summary>
public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="MovieService"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor creates a new <see cref="MovieService"/> instance.
    /// </remarks>
    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    /// <summary>
    /// Service that lists Movies based on the provided filter and pagination criteria.
    /// </summary>
    /// <param name="filter">The filter to apply on the Movies list</param>
    /// <param name="pageable">The pagination criteria to apply on the resulting list</param>
    /// <returns>A pagination result containing a list of MovieDto objects</returns>
    public async Task<List<Movie>> List(MovieFilter filter)
    {
        return await _movieRepository.Search(filter);
    }

    /// <summary>
    /// Service that gets a Movie by its unique id.
    /// </summary>
    /// <param name="id">The unique id of the Movie</param>
    /// <returns>The MovieDto object that matches the provided id, or null if none is found</returns>
    public async Task<Movie?> Get(Guid id)
    {
        return await _movieRepository.GetById(id) ?? null;
    }

    /// <summary>
    /// Service that creates a new Movie.
    /// </summary>
    /// <param name="movie">The Movie object to create</param>
    /// <returns>The MovieDto object that represents the newly created Movie</returns>
    public async Task<Movie> Create(Movie movie)
    {
        return await _movieRepository.Add(movie);
    }

    /// <summary>
    /// Service that updates a Movie with the provided id.
    /// </summary>
    /// <param name="id">The unique id of the Movie to update</param>
    /// <param name="updatedMovie">The updated Movie object</param>
    /// <returns>The MovieDto object that represents the updated Movie, or null if none is found</returns>
    public async Task<Movie?> Update(Guid id, Movie updatedMovie)
    {
        return await _movieRepository.Update(id, updatedMovie);
    }

    /// <summary>
    /// Service that deletes a Movie with the provided id.
    /// </summary>
    /// <param name="id">The unique id of the Movie to delete</param>
    /// <returns>No Content</returns>
    public async Task<Movie?> Delete(Guid id)
    {
        return await _movieRepository.Delete(id) ?? null;
    }
}