using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Main.Api.Dtos.Input.Create;

/// <summary>
/// Input for Movie creation
/// </summary>
public class MovieInputCreate
{
    /// <summary>
    /// Movie's title
    /// </summary>
    /// <example>John Wick: Baba Yaga</example>
    [Required]
    public string Title { get; set; } = null!;
    
    /// <summary>
    /// Movie's genre
    /// </summary>
    /// <example>Ação</example>
    [Required]
    public string Genre { get; set; } = null!;
    
    /// <summary>
    /// Movie's duration
    /// </summary>
    /// <example>280</example>
    [Required]
    [Range(70,600)]
    public int Duration { get; set; }
}