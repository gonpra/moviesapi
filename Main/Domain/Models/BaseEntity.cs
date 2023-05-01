namespace MoviesApi.Main.Domain.Models;

/// <summary>
/// The BaseEntity class represents a base entity in the application domain model.
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// Gets or sets the unique identifier of the entity.
    /// </summary>
    public Guid Id { get; set; }
}