using Microsoft.AspNetCore.Mvc;
using EntityFramework.Models.Interfaces;
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
            .Select(name => new GenreDto { Name = name })
            .ToList();

        return Ok(genreDtos);
    }
}