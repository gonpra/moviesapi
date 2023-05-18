using MoviesApi.Main.Domain.Models;
using MoviesApi.Main.Api.Dtos.Filter;
using MongoDB.Driver;
using MoviesApi.Main.Core.Database;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
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
    /// </remarks>
    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    /// <summary>
    /// Service that lists Movies based on the provided filter and pagination criteria.
    /// </summary>
    /// <param name="filter">The filter to apply on the Movies list</param>
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
    public async Task<Movie?> Get(ObjectId id)
    {
        return await _movieRepository.GetById(id);
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
    /// <param name="movie">The updated Movie object</param>
    /// <returns>The MovieDto object that represents the updated Movie, or null if none is found</returns>
    public async Task<Movie?> Update(ObjectId id, Movie movie)
    {
        return await _movieRepository.Update(id, movie);
    }

    /// <summary>
    /// Service that deletes a Movie with the provided id.
    /// </summary>
    /// <param name="id">The unique id of the Movie to delete</param>
    /// <returns>No Content</returns>
    public async Task<ObjectId?> Delete(ObjectId id)
    {
        return await _movieRepository.Delete(id);
    }
}
