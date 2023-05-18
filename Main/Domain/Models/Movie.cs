using MongoDB.Bson.Serialization.Attributes;

namespace MoviesApi.Main.Domain.Models;

/// <summary>
/// Represents a movie object.
/// </summary>
public class Movie : BaseEntity
{
    /// <summary>
    /// Gets or sets the title of the movie.
    /// </summary>
    /// <example>John Wick: Baba Yaga</example>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Gets or sets the genre of the movie.
    /// </summary>
    /// <example>Action</example>
    public string Genre { get; set; } = null!;

    /// <summary>
    /// Gets or sets the duration of the movie in minutes.
    /// </summary>
    /// <example>120</example>
    public int Duration { get; set; }
}
