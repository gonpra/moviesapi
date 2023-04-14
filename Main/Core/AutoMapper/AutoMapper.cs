using AutoMapper;
using FilmesApi.Main.Api.Dtos;
using FilmesApi.Main.Api.Dtos.Input.Create;
using FilmesApi.Main.Api.Dtos.Input.Edit;
using FilmesApi.Main.Domain.Models;

namespace FilmesApi.Main.Core.AutoMapper;

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
            cfg.CreateMap<FilmeInputCreate, Filme>();
            cfg.CreateMap<Filme, FilmeDto>();
            cfg.CreateMap<FilmeInputEdit, Filme>();
            cfg.CreateMap<Filme, Filme>();
        });
        
        var mapper = new Mapper(config);
        return mapper;
    }
}
