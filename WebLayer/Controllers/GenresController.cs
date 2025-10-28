using EntityFramework.Interfaces;
using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using WebLayer.Dtos;

namespace WebLayer.Controllers;

[ApiController]
[Route("api/genres")]
public class GenresController : ControllerBase
{
    IGenreData _genreData;
    private readonly LinkGenerator _generator;
    public GenresController(IGenreData genreData, LinkGenerator generator)
    {
     _genreData = genreData;
    _generator = generator;
    }
    [HttpGet]
    public ActionResult<IEnumerable<GenreDto>> GetGenres()
    {
        var genres = _genreData.GetGenres().Select(x => CreateGenreDto(x));
        return Ok(genres);
    }

    [HttpGet("{id}", Name = nameof(GetById))]
    public ActionResult<GenreDto> GetById(int id)
    {
        var genre = _genreData.GetById(id);
        var genreDto = CreateGenreDto(genre);
        return Ok(genreDto);
    }

    private GenreDto CreateGenreDto(Genre genre)
    {
        return new GenreDto
        {
            Url = GetUrl(nameof(GetById), new { id = genre.GenreId }),
            Name = genre.GenreName
        };
    }

    private string? GetUrl(string endpointName, object values)
    {
         return _generator.GetUriByName(HttpContext,endpointName,values );
    }
    
}