
namespace FilmesApi.Main.Api.Dtos.Filter;

/// <summary>
/// Filter for Filme.
/// </summary>
public class FilmeFilter
{
    /// <summary>
    /// Titulo field.
    /// </summary>
    public string? Titulo { get; set; } = null;
    /// <summary>
    /// Genero field.
    /// </summary>
    public string? Genero { get; set; } = null;
    /// <summary>
    /// Duracao field.
    /// </summary>
    public int? Duracao { get; set; } = null;
}