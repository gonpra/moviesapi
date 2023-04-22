using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Main.Api.Dtos.Input.Edit;

/// <summary>
/// Represents the input for editing a Movie.
/// </summary>
public class MovieInputEdit
{
    /// <summary>
    /// Gets or sets the title of the Movie.
    /// </summary>
    /// <example>John Wick: Baba Yaga</example>
    [Required]
    public string Title { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the genre of the Movie.
    /// </summary>
    /// <example>Action</example>
    [Required]
    public string Genre { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the duration of the Movie, in minutes.
    /// </summary>
    /// <example>280</example>
    [Required]
    [Range(70, 600)]
    public int Duration { get; set; }
}