using EntityFramework.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebLayer.Dtos;

namespace WebLayer.Controllers;

[ApiController]
[Route("api/genres")]
public class GenresController(IGenreData genreData) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<GenreDto>> GetGenres()
    {
        var genreNames = genreData.GetGenres();

        var genreDtos = genreNames
            .Select(g => new GenreDto { Name = g.GenreName })
            .ToList();

        return Ok(genreDtos);
    }

    [HttpGet("{id}")]
    public ActionResult<GenreDto> GetById(int id)
    {
        var genre = genreData.GetById(id);

        return Ok(new GenreDto { Name = genre.GenreName });
    }
    
}