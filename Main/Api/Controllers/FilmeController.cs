using Microsoft.AspNetCore.Mvc;
using FilmesApi.Main.Api.Services;
using FilmesApi.Main.Api.Dtos.Input.Create;
using FilmesApi.Main.Api.Dtos.Input.Edit;
using FilmesApi.Main.Api.Dtos;
using FilmesApi.Main.Api.Dtos.Filter;
using FilmesApi.Main.Core.Pagination;
using FilmesApi.Main.Core.AutoMapper;
using FilmesApi.Main.Domain.Models;
using AutoMapper;

namespace FilmesApi.Main.Api.Controllers;

/// <summary>
/// Represents the Filme controller that manages CRUD operations for Filme objects.
/// </summary>
[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private readonly Mapper _mapper;
    private readonly FilmeService _filmeService;

    /// <summary>
    /// Initializes a new instance of the <see cref="FilmeController"/> class.
    /// </summary>
    public FilmeController()
    {
        _mapper = MapperConfig.InitAutoMapper();
        _filmeService = new FilmeService();
    }
    
    /// <summary>
    /// Creates a new Filme object.
    /// </summary>
    /// <param name="input">The input data for creating a new Filme.</param>
    /// <returns>A newly created Filme.</returns>
    /// <response code="201">Returns the newly created Filme.</response>
    /// <response code="500">If an error occurs while processing the request.</response>
    /// <response code="400">If the input data is incorrect.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    public async Task<ActionResult<FilmeDto>> Create([FromBody] FilmeInputCreate input)
    {
        FilmeDto content = await _filmeService.Create(_mapper.Map<FilmeInputCreate, Filme>(input));
        
        return CreatedAtAction(
            nameof(Get),
            new { id = content.Id },
            content
        );
    }

    /// <summary>
    /// Lists Filme objects with optional filtering and paging.
    /// </summary>
    /// <param name="filter">The filter criteria for listing Filme objects.</param>
    /// <param name="pageable">The pagination criteria for listing Filme objects.</param>
    /// <returns>A list of Filme objects that match the filter criteria.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public async Task<ActionResult<Pagination<List<FilmeDto>>>> List([FromQuery] FilmeFilter filter, [FromQuery] Pageable pageable)
    {
        Pagination<List<FilmeDto>> content = await _filmeService.List(filter, pageable);
        
        return Ok(content);
    }    

    /// <summary>
    /// Gets the Filme object with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the Filme object to get.</param>
    /// <returns>The Filme object with the specified ID.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public async Task<ActionResult<FilmeDto?>> Get([FromRoute] Guid id)
    {
        FilmeDto? content = _filmeService.Get(id);

        if (content == null)
        {
            return NotFound();
        }
        
        return Ok(content);
    }

    /// <summary>
    /// Updates the Filme object with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the Filme object to update.</param>
    /// <param name="inputRaw">The input data for updating the Filme object.</param>
    /// <returns>The updated Filme object.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public async Task<ActionResult<FilmeDto?>> Update([FromRoute] Guid id, [FromBody] FilmeInputEdit inputRaw)
    {
        // Convert 'FilmeInputEdit' object to a 'Filme' object
        Filme input = _mapper.Map<FilmeInputEdit, Filme>(inputRaw);

        FilmeDto? content = await _filmeService.Update(id, input);
        
        if (content is null)
        {
            return NotFound();
        }

        return Ok(content);
    }
   
    /// <summary>
    /// Deletes a Filme by ID.
    /// </summary>
    /// <param name="id">The ID of the Filme to be deleted.</param>
    /// <returns>Returns a HTTP response with no content (204) if the Filme was successfully deleted.
    /// If the Filme is not found, the method returns a HTTP response with status code 404.
    /// If an unexpected error occurs, the method returns a HTTP response with status code 500.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        FilmeDto? content = await _filmeService.Delete(id);
     
        if (content is null)
        {
            return NotFound();
        }

        return NoContent();
    }
}