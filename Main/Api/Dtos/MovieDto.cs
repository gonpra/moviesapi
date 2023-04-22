namespace MoviesApi.Main.Api.Dtos;

/// <summary>
/// Represents a Movie Data Transfer Object (DTO).
/// </summary>
public class MovieDto
{
    /// <summary>
    /// Gets or sets the unique identifier of the Movie.
    /// </summary>
    /// <example>3fa85f64-5717-4562-b3fc-2c963f66afa6</example>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets the title of the Movie.
    /// </summary>
    /// <example>John Wick: Baba Yaga</example>
    public string Title { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the genre of the Movie.
    /// </summary>
    /// <example>Action</example>
    public string Genre { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the duration of the Movie in minutes.
    /// </summary>
    /// <example>120</example>
    public int Duration { get; set; }
}