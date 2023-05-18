namespace MoviesApi.Main.Core.Database;

/// <summary>
/// Represents the data context for getting information to access the database.
/// </summary>
public class DataContext
{
    /// <summary>
    /// Gets or sets the connection string for the database.
    /// </summary>
    public string ConnectionString { get; set; } = null!;

    /// <summary>
    /// Gets or sets the name of the database.
    /// </summary>
    public string DatabaseName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the name of the collection within the database.
    /// </summary>
    public string CollectionName { get; set; } = null!;
}

