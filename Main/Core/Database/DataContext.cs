using Microsoft.EntityFrameworkCore;
using MoviesApi.Main.Domain.Models;

namespace MoviesApi.Main.Core.Database;

/// <summary>
/// The DataContext class provides a database context for interacting with a Postgres database using Entity Framework Core.
/// </summary>
/// <remarks>
/// This class extends the DbContext class and contains a constructor that initializes a new instance of the class with the specified DbContextOptions and IConfiguration.
/// The DbContextOptions object contains the options for configuring the DbContext, while the IConfiguration object contains the configuration settings for the application.
/// This class also overrides the OnConfiguring method to set the database provider to Npgsql, which is a .NET data provider for Postgres databases.
/// The database connection string is retrieved from the IConfiguration object using the "WebApiDatabase" key.
/// </remarks>
public class DataContext : DbContext
{

    private readonly IConfiguration _configuration = null!;
    
    /// <summary>
    /// Constructor for the DataContext class that initializes a new instance of the class with the specified DbContextOptions and IConfiguration.
    /// </summary>
    /// <param name="options">DbContextOptions object containing the options for configuring the DbContext.</param>
    /// <param name="configuration">IConfiguration object containing the configuration settings for the application.</param>
    /// <remarks>
    /// This constructor initializes a new instance of the DataContext class with the specified DbContextOptions and IConfiguration.
    /// The DbContextOptions object contains the options for configuring the DbContext, while the IConfiguration object contains the configuration settings for the application.
    /// </remarks>
    public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DataContext"/> class with the specified <see cref="DbContextOptions{TContext}"/> object.
    /// </summary>
    /// <param name="options">The <see cref="DbContextOptions{TContext}"/> object containing the options for configuring the DbContext.</param>
    /// <remarks>
    /// This constructor initializes a new instance of the <see cref="DataContext"/> class with the specified <see cref="DbContextOptions{TContext}"/> object.
    /// The <see cref="DbContextOptions{TContext}"/> object contains the options for configuring the DbContext.
    /// </remarks>
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        // Empty constructor.
    }

    
    /// <summary>
    /// Configures the options for the current DbContext instance using the specified DbContextOptionsBuilder object.
    /// </summary>
    /// <param name="optionsBuilder">An instance of DbContextOptionsBuilder to configure the DbContext options.</param>
    /// <remarks>
    /// This method overrides the base method and sets the database provider to Npgsql, which is a .NET data provider for Postgres databases.
    /// The database connection string is retrieved from the IConfiguration object using the "WebApiDatabase" key.
    /// </remarks>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("WebApiDatabase"));
    }

    /// <summary>
    /// Movie database instance.
    /// </summary>
    public DbSet<Movie> Movies { get; set; } = null!;
}