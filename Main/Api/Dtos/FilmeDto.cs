namespace FilmesApi.Main.Api.Dtos;

/// <summary>
/// Represents a Filme Data Transfer Object (DTO).
/// </summary>
public class FilmeDto
{
    /// <summary>
    /// Gets or sets the unique identifier of the filme.
    /// </summary>
    /// <example>3fa85f64-5717-4562-b3fc-2c963f66afa6</example>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets the title of the filme.
    /// </summary>
    /// <example>John Wick: Chapter 4</example>
    public string Titulo { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the genre of the filme.
    /// </summary>
    /// <example>Action</example>
    public string Genero { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the duration of the filme in minutes.
    /// </summary>
    /// <example>120</example>
    public int Duracao { get; set; }
}