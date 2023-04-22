using AutoMapper;
using MoviesApi.Main.Api.Dtos;
using MoviesApi.Main.Api.Dtos.Filter;
using MoviesApi.Main.Core.AutoMapper;
using MoviesApi.Main.Core.Pagination;
using MoviesApi.Main.Domain.Models;

namespace MoviesApi.Main.Api.Services;

/// <summary>
/// Service class for managing Movies.
/// </summary>
public class MovieService
{
    private readonly Mapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="MovieService"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor creates a new <see cref="MovieService"/> instance and initializes its mapper using the 
    /// configuration defined in <see cref="MapperConfig"/>. The mapper is used to map objects between different 
    /// representations of Movie objects in the service and in client code.
    /// </remarks>
    public MovieService()
    {
        _mapper = MapperConfig.InitAutoMapper();
    }
    
    private static List<Movie> _movies = new List<Movie>();

    /// <summary>
    /// Service that lists Movies based on the provided filter and pagination criteria.
    /// </summary>
    /// <param name="filter">The filter to apply on the Movies list</param>
    /// <param name="pageable">The pagination criteria to apply on the resulting list</param>
    /// <returns>A pagination result containing a list of MovieDto objects</returns>
    public async Task<Pagination<List<MovieDto>>> List(MovieFilter filter, Pageable pageable)
    {
        IEnumerable<Movie> content = _movies.Where(movie =>
            {
                return (filter.Title ?? movie.Title) == movie.Title
                       && (filter.Genre ?? movie.Genre) == movie.Genre
                       && (filter.Duration ?? movie.Duration) == movie.Duration;
            }
        );

        List<MovieDto> dto = new List<MovieDto>();
        foreach (var movie in content)
        {
            dto.Add(_mapper.Map<Movie, MovieDto>(movie));
        }

        List<MovieDto> filteredContent = Pagination<MovieDto>.Paginate(dto, pageable);

        return new Pagination<List<MovieDto>>(filteredContent, pageable, content.Count());
    }

    /// <summary>
    /// Service that gets a Movie by its unique id.
    /// </summary>
    /// <param name="id">The unique id of the Movie</param>
    /// <returns>The MovieDto object that matches the provided id, or null if none is found</returns>
    public async Task<MovieDto?> Get(Guid id)
    {
        Movie? movie = _movies.FirstOrDefault(f => f.Id == id);
        if (movie is null)
        {
            return null;
        }

        return _mapper.Map<Movie, MovieDto>(movie);
    }

    /// <summary>
    /// Service that creates a new Movie.
    /// </summary>
    /// <param name="movie">The Movie object to create</param>
    /// <returns>The MovieDto object that represents the newly created Movie</returns>
    public async Task<MovieDto> Create(Movie movie)
    {
        movie.Id = Guid.NewGuid();
        _movies.Add(movie);

        return _mapper.Map<Movie, MovieDto>(movie);
    }

    /// <summary>
    /// Service that updates a Movie with the provided id.
    /// </summary>
    /// <param name="id">The unique id of the Movie to update</param>
    /// <param name="updatedMovie">The updated Movie object</param>
    /// <returns>The MovieDto object that represents the updated Movie, or null if none is found</returns>
    public async Task<MovieDto?> Update(Guid id, Movie updatedMovie)
    {
        Movie? movie = _movies.FirstOrDefault(f => f.Id == id);
        if (movie is null)
        {
            return null;
        }

        movie.Title = updatedMovie.Title;
        movie.Genre = updatedMovie.Genre;
        movie.Duration = updatedMovie.Duration;

        return _mapper.Map<Movie, MovieDto>(movie);
    }

    /// <summary>
    /// Service that deletes a Movie with the provided id.
    /// </summary>
    /// <param name="id">The unique id of the Movie to delete</param>
    /// <returns>No Content</returns>
    public async Task<MovieDto?> Delete(Guid id)
    {
        Movie? movie = _movies.Find(f => f.Id == id);

        if (movie is null)
        {
            return null;
        }

        _movies.Remove(movie);
        
        return _mapper.Map<Movie, MovieDto>(movie);
    }
}