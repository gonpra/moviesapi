using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Main.Api.Dtos.Input.Create;

/// <summary>
/// Input for filme creation
/// </summary>
public class FilmeInputCreate
{
    /// <summary>
    /// Filme's titulo
    /// </summary>
    /// <example>John Wick: Chapter 4</example>
    [Required]
    public string Titulo { get; set; } = null!;
    
    /// <summary>
    /// Filme's genero
    /// </summary>
    /// <example>Ação</example>
    [Required]
    public string Genero { get; set; } = null!;
    
    /// <summary>
    /// Filme's duracao
    /// </summary>
    /// <example>280</example>
    [Required]
    [Range(70,600)]
    public int Duracao { get; set; }
}