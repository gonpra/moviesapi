
namespace MoviesApi.Main.Api.Dtos.Filter;

/// <summary>
/// Filter for Movie.
/// </summary>
public class MovieFilter
{
    /// <summary>
    /// Title field.
    /// </summary>
    public string? Title { get; set; } = null;
    /// <summary>
    /// Genre field.
    /// </summary>
    public string? Genre { get; set; } = null;
    /// <summary>
    /// Duration field.
    /// </summary>
    public int? Duration { get; set; } = null;
}