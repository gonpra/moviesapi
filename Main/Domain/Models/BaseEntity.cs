namespace MoviesApi.Main.Domain.Models;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

/// <summary>
/// Represents a base entity object.
/// </summary>
public class BaseEntity
{
    /// <summary>
    ///  Gets or sets the Id of the base entity.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
}
