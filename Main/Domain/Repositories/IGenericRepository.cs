using MongoDB.Bson;

namespace MoviesApi.Main.Domain.Repositories;

/// <summary>
/// The IGenericRepository interface provides a generic interface for performing basic CRUD operations on a data source.
/// </summary>
public interface IGenericRepository<T>
{
    /// <summary>
    /// Gets a list of entities of the specified type T from the data source.
    /// </summary>
    /// <typeparam name="T">The type of entity to retrieve.</typeparam>
    /// <returns>An asynchronous operation that returns an IEnumerable of entities of the specified type T.</returns>
    Task<List<T>> GetAll();
    
    /// <summary>
    /// Gets the entity of the specified type T with the specified identifier from the data source.
    /// </summary>
    /// <typeparam name="T">The type of entity to retrieve.</typeparam>
    /// <returns>An asynchronous operation that returns the entity of the specified type T with the specified identifier.</returns>
    Task<T?> GetById(ObjectId id);

    /// <summary>
    /// Adds the specified entity of type T to the data source.
    /// </summary>
    /// <typeparam name="T">The type of entity to add.</typeparam>
    /// <param name="entity">The entity of type T to add to the data source.</param>
    /// <returns>An asynchronous operation that returns the entity of the specified type T that was added to the data source.</returns>
    Task<T> Add(T entity);

    /// <summary>
    /// Updates the specified entity of type T in the data source.
    /// </summary>
    /// <typeparam name="T">The type of entity to update.</typeparam>
    /// <param name="id">The id of the entity to update.</param>
    /// <param name="entity">The entity of type T to update in the data source.</param>
    /// <returns>An asynchronous operation that returns the entity of the specified type T that was updated in the data source.</returns>
    Task<T> Update(ObjectId id, T entity);

    /// <summary>
    /// Deletes the entity of type T with the specified identifier from the data source.
    /// </summary>
    /// <typeparam name="T">The type of entity to delete.</typeparam>
    /// <param name="id">The identifier of the entity of type T to delete from the data source.</param>
    Task<ObjectId?> Delete(ObjectId id);
}