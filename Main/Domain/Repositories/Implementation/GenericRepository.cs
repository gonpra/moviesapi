using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MoviesApi.Main.Core.Database;
using MoviesApi.Main.Domain.Models;

namespace MoviesApi.Main.Domain.Repositories.Implementation;

/// <summary>
/// Provides a generic repository implementation for working with entities of type <typeparamref name="T"/> in a database.
/// </summary>
/// <typeparam name="T">The entity type to work with.</typeparam>
/// <remarks>
/// This class implements the <see cref="IGenericRepository{T}"/> interface and provides CRUD operations for entities of type <typeparamref name="T"/>.
/// The class requires a <see cref="DataContext"/> object to be passed in during construction, which is used to interact with the database.
/// </remarks>
public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity
{
    private readonly IMongoCollection<T> _collection;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
    /// </summary>
    /// <param name="context">The <see cref="DataContext"/> object to be used by the repository.</param>
    protected GenericRepository(IOptions<DataContext> context)
    {
        var client = new MongoClient(context.Value.ConnectionString);
        var db = client.GetDatabase(context.Value.DatabaseName);
        _collection = db.GetCollection<T>(context.Value.CollectionName);
    }
    
     /// <summary>
    /// Gets all entities of type T.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="List{T}"/> of entities of type T.</returns>
    public async Task<List<T>> GetAll()
     {
         return await _collection.Find(x => true).ToListAsync();
     }

    /// <summary>
    /// Gets an entity of type T by ID.
    /// </summary>
    /// <param name="id">The ID of the entity to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an entity of type T or null if no entity is found with the specified ID.</returns>
    public async Task<T?> GetById(ObjectId id)
    {
        return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    /// <summary>
    /// Adds a new entity of type T to the repository.
    /// </summary>
    /// <param name="entity">The entity of type T to add to the repository.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the added entity of type T.</returns>
    public async Task<T> Add(T entity)
    {
        await _collection.InsertOneAsync(entity);

        return entity;
    }

    /// <summary>
    /// Updates an entity of type T in the repository.
    /// </summary>
    /// <param name="id">The ID of the entity to update.</param>
    /// <param name="entity">The entity of type T to update in the repository.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated entity of type T.</returns>
    public async Task<T> Update(ObjectId id, T entity)
    {
        entity.Id = id;
        
        await _collection.ReplaceOneAsync(x => x.Id == id, entity);

        return entity;
    }

    /// <summary>
    /// Deletes an entity of type T from the repository by ID.
    /// </summary>
    /// <param name="id">The ID of the entity to delete from the repository.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deleted entity of type T or null if no entity is found with the specified ID.</returns>
    public async Task<ObjectId?> Delete(ObjectId id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);

        return id;
    }
}