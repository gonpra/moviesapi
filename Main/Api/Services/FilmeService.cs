using AutoMapper;
using FilmesApi.Main.Api.Dtos;
using FilmesApi.Main.Core.AutoMapper;
using FilmesApi.Main.Domain.Models;
using FilmesApi.Main.Core.Pagination;
using FilmesApi.Main.Api.Dtos.Filter;

namespace FilmesApi.Main.Api.Services;

/// <summary>
/// Service class for managing Filmes.
/// </summary>
public class FilmeService
{
    private readonly Mapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="FilmeService"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor creates a new <see cref="FilmeService"/> instance and initializes its mapper using the 
    /// configuration defined in <see cref="MapperConfig"/>. The mapper is used to map objects between different 
    /// representations of Filme objects in the service and in client code.
    /// </remarks>
    public FilmeService()
    {
        _mapper = MapperConfig.InitAutoMapper();
    }
    
    private static List<Filme> _filmes = new List<Filme>();

    /// <summary>
    /// Service that lists Filmes based on the provided filter and pagination criteria.
    /// </summary>
    /// <param name="filter">The filter to apply on the Filmes list</param>
    /// <param name="pageable">The pagination criteria to apply on the resulting list</param>
    /// <returns>A pagination result containing a list of FilmeDto objects</returns>
    public async Task<Pagination<List<FilmeDto>>> List(FilmeFilter filter, Pageable pageable)
    {
        IEnumerable<Filme> content = _filmes.Where(filme =>
            {
                return (filter.Titulo ?? filme.Titulo) == filme.Titulo
                       && (filter.Genero ?? filme.Genero) == filme.Genero
                       && (filter.Duracao ?? filme.Duracao) == filme.Duracao;
            }
        );

        List<FilmeDto> dto = new List<FilmeDto>();
        foreach (var filme in content)
        {
            dto.Add(_mapper.Map<Filme, FilmeDto>(filme));
        }

        List<FilmeDto> filteredContent = Pagination<FilmeDto>.Paginate(dto, pageable);

        return new Pagination<List<FilmeDto>>(filteredContent, pageable, content.Count());
    }

    /// <summary>
    /// Service that gets a Filme by its unique id.
    /// </summary>
    /// <param name="id">The unique id of the Filme</param>
    /// <returns>The FilmeDto object that matches the provided id, or null if none is found</returns>
    public FilmeDto? Get(Guid id)
    {
        Filme? filme = _filmes.FirstOrDefault(f => f.Id == id);
        if (filme is null)
        {
            return null;
        }

        return _mapper.Map<Filme, FilmeDto>(filme);
    }

    /// <summary>
    /// Service that creates a new Filme.
    /// </summary>
    /// <param name="filme">The Filme object to create</param>
    /// <returns>The FilmeDto object that represents the newly created Filme</returns>
    public async Task<FilmeDto> Create(Filme filme)
    {
        filme.Id = Guid.NewGuid();
        _filmes.Add(filme);

        return _mapper.Map<Filme, FilmeDto>(filme);
    }

    /// <summary>
    /// Service that updates a Filme with the provided id.
    /// </summary>
    /// <param name="id">The unique id of the Filme to update</param>
    /// <param name="updatedFilme">The updated Filme object</param>
    /// <returns>The FilmeDto object that represents the updated Filme, or null if none is found</returns>
    public async Task<FilmeDto?> Update(Guid id, Filme updatedFilme)
    {
        Filme? filme = _filmes.FirstOrDefault(f => f.Id == id);
        if (filme is null)
        {
            return null;
        }

        filme.Titulo = updatedFilme.Titulo;
        filme.Genero = updatedFilme.Genero;
        filme.Duracao = updatedFilme.Duracao;

        return _mapper.Map<Filme, FilmeDto>(filme);
    }

    /// <summary>
    /// Service that deletes a Filme with the provided id.
    /// </summary>
    /// <param name="id">The unique id of the Filme to delete</param>
    /// <returns>No Content</returns>
    public async Task<FilmeDto?> Delete(Guid id)
    {
        Filme? filme = _filmes.Find(f => f.Id == id);

        if (filme is null)
        {
            return null;
        }

        return _mapper.Map<Filme, FilmeDto>(filme);
    }
}