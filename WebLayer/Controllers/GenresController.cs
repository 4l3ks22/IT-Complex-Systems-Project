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
            .Select(g => new GenreDto { Name = g.GenreName })
            .ToList();

        return Ok(genreDtos);
    }
}