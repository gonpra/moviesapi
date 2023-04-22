using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MoviesApi.Main.Api.Dtos;
using MoviesApi.Main.Api.Dtos.Filter;
using MoviesApi.Main.Api.Dtos.Input.Create;
using MoviesApi.Main.Api.Dtos.Input.Edit;
using MoviesApi.Main.Api.Services;
using MoviesApi.Main.Core.AutoMapper;
using MoviesApi.Main.Core.Pagination;
using MoviesApi.Main.Domain.Models;

namespace MoviesApi.Main.Api.Controllers;

/// <summary>
/// Represents the Movie controller that manages CRUD operations for Movie objects.
/// </summary>
[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly Mapper _mapper;
    private readonly MovieService _movieService;

    /// <summary>
    /// Initializes a new instance of the <see cref="MovieController"/> class.
    /// </summary>
    public MovieController()
    {
        _mapper = MapperConfig.InitAutoMapper();
        _movieService = new MovieService();
    }
    
    /// <summary>
    /// Creates a new Movie object.
    /// </summary>
    /// <param name="input">The input data for creating a new Movie.</param>
    /// <returns>A newly created Movie.</returns>
    /// <response code="201">Returns the newly created Movie.</response>
    /// <response code="500">If an error occurs while processing the request.</response>
    /// <response code="400">If the input data is incorrect.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    public async Task<ActionResult<MovieDto>> Create([FromBody] MovieInputCreate input)
    {
        var content = await _movieService.Create(_mapper.Map<MovieInputCreate, Movie>(input));
        
        return CreatedAtAction(
            nameof(Get),
            new { id = content.Id },
            content
        );
    }

    /// <summary>
    /// Lists Movie objects with optional filtering and paging.
    /// </summary>
    /// <param name="filter">The filter criteria for listing Movie objects.</param>
    /// <param name="pageable">The pagination criteria for listing Movie objects.</param>
    /// <returns>A list of Movie objects that match the filter criteria.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public async Task<ActionResult<Pagination<List<MovieDto>>>> List([FromQuery] MovieFilter filter, [FromQuery] Pageable pageable)
    {
        var content = await _movieService.List(filter, pageable);
        
        return Ok(content);
    }    

    /// <summary>
    /// Gets the Movie object with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the Movie object to get.</param>
    /// <returns>The Movie object with the specified ID.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public async Task<ActionResult<MovieDto?>> Get([FromRoute] Guid id)
    {
        var content = await _movieService.Get(id);

        if (content == null)
        {
            return NotFound();
        }
        
        return Ok(content);
    }

    /// <summary>
    /// Updates the Movie object with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the Movie object to update.</param>
    /// <param name="inputRaw">The input data for updating the Movie object.</param>
    /// <returns>The updated Movie object.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public async Task<ActionResult<MovieDto?>> Update([FromRoute] Guid id, [FromBody] MovieInputEdit inputRaw)
    {
        // Convert 'MovieInputEdit' object to a 'Movie' object
        var input = _mapper.Map<MovieInputEdit, Movie>(inputRaw);

        var content = await _movieService.Update(id, input);
        
        if (content is null)
        {
            return NotFound();
        }

        return Ok(content);
    }
   
    /// <summary>
    /// Deletes a Movie by ID.
    /// </summary>
    /// <param name="id">The ID of the Movie to be deleted.</param>
    /// <returns>Returns a HTTP response with no content (204) if the Movie was successfully deleted.
    /// If the Movie is not found, the method returns a HTTP response with status code 404.
    /// If an unexpected error occurs, the method returns a HTTP response with status code 500.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        var content = await _movieService.Delete(id);
     
        if (content is null)
        {
            return NotFound();
        }

        return NoContent();
    }
}