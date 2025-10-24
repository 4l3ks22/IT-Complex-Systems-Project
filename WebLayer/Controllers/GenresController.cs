using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EntityFramework.Models.Interfaces;

namespace WebLayer.Controllers;

[ApiController]
[Route("api/genres")]
public class GenresController : ControllerBase
{
    private readonly IGenreData _genreData;

    public GenresController(IGenreData genreData) => _genreData = genreData;

    [HttpGet]
    public ActionResult<IEnumerable<string>> GetGenres()
    {
        var genres = _genreData.GetGenres();
        return Ok(genres ?? new List<string>());
    }
}