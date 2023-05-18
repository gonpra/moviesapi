using System.Reflection;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using MoviesApi.Main.Api.Services;
using MoviesApi.Main.Api.Services.Implementation;
using MoviesApi.Main.Core.Database;
using MoviesApi.Main.Domain.Repositories;
using MoviesApi.Main.Domain.Repositories.Implementation;

// BUILDER CONFIG
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Filmes API",
        Description = "An ASP.NET Core Web API for managing Filmes"
    });

    String xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    
    // Treat ObjectId as a String in Swagger
    options.MapType<ObjectId>(() => new OpenApiSchema { Type = "string" });
});

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddProblemDetails(options =>
        options.CustomizeProblemDetails = ctx =>
            ctx.ProblemDetails.Extensions.Add("nodeId", Environment.MachineName));
}

builder.Services.Configure<DataContext>(builder.Configuration.GetSection("MongoDatabase"));

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

// APP CONFIG

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // /swagger/index.html
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });

}

app.UseStatusCodePages();

app.UseExceptionHandler("/problem");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
