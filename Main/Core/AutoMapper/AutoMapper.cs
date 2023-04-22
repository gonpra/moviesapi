using AutoMapper;
using MoviesApi.Main.Api.Dtos;
using MoviesApi.Main.Api.Dtos.Input.Create;
using MoviesApi.Main.Api.Dtos.Input.Edit;
using MoviesApi.Main.Domain.Models;

namespace MoviesApi.Main.Core.AutoMapper;

/// <summary>
/// A class for configuring AutoMapper and creating an instance of it.
/// </summary>
public class MapperConfig
{
    /// <summary>
    /// Initializes AutoMapper and returns an instance of it.
    /// </summary>
    /// <returns>An instance of the AutoMapper.</returns>
    public static Mapper InitAutoMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<MovieInputCreate, Movie>();
            cfg.CreateMap<Movie, MovieDto>();
            cfg.CreateMap<MovieInputEdit, Movie>();
            cfg.CreateMap<Movie, Movie>();
        });
        
        var mapper = new Mapper(config);
        return mapper;
    }
}
