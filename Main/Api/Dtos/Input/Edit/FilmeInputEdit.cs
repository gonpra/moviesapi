using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Main.Api.Dtos.Input.Edit;

/// <summary>
/// Represents the input for editing a filme.
/// </summary>
public class FilmeInputEdit
{
    /// <summary>
    /// Gets or sets the titulo of the filme.
    /// </summary>
    /// <example>John Wick: Chapter 4</example>
    [Required]
    public string Titulo { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the genero of the filme.
    /// </summary>
    /// <example>Ação</example>
    [Required]
    public string Genero { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the duracao of the filme, in minutes.
    /// </summary>
    /// <example>280</example>
    [Required]
    [Range(70, 600)]
    public int Duracao { get; set; }
}