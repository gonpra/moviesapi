namespace FilmesApi.Main.Domain.Models;

/// <summary>
/// Represents a movie object.
/// </summary>
public class Filme
{
    /// <summary>
    /// Gets or sets the unique identifier of the movie.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the movie.
    /// </summary>
    /// <example>John Wick: Baba Yaga</example>
    public string Titulo { get; set; } = null!;

    /// <summary>
    /// Gets or sets the genre of the movie.
    /// </summary>
    /// <example>Ação</example>
    public string Genero { get; set; } = null!;

    /// <summary>
    /// Gets or sets the duration of the movie in minutes.
    /// </summary>
    /// <example>120</example>
    public int Duracao { get; set; }
}