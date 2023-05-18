using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MoviesApi.Main.Api.Dtos.Filter;
using MoviesApi.Main.Core.Database;
using MoviesApi.Main.Core.Utils;
using MoviesApi.Main.Domain.Models;

namespace MoviesApi.Main.Domain.Repositories.Implementation;

/// <summary>
/// A class that represents a movie repository and inherits from the generic repository of type Movie. Implements the IMovieRepository interface.
/// </summary>
public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    private readonly IMongoCollection<Movie> _movieCollection;

    /// <summary>
    /// Constructor for the MovieRepository class that initializes a new instance of the class with the specified DataContext.
    /// </summary>
    public MovieRepository(IOptions<DataContext> context) : base(context)
    {
        var client = new MongoClient(context.Value.ConnectionString);
        var db = client.GetDatabase(context.Value.DatabaseName);
        _movieCollection = db.GetCollection<Movie>(context.Value.CollectionName);
    }
    
    /// <summary>
    /// Retrieves a paginated list of all movies.
    /// </summary>
    /// <returns>A Pagination object containing a list of movies and pagination metadata.</returns>
    public async Task<List<Movie>> Search(MovieFilter filter)
    {
        if (Static.IsAllPropertyNullOrEmpty(filter))
        {
            return await _movieCollection.Find(x => true).ToListAsync();
        }
        
        var builder = Builders<Movie>.Filter; 
        var builderFilter = 
            builder.Eq(movie => movie.Title, filter.Title) |
            builder.Eq(movie => movie.Genre, filter.Genre) | 
            builder.Eq(movie => movie.Duration, filter.Duration);
        
        return await _movieCollection.Find(builderFilter).ToListAsync();
    }
}