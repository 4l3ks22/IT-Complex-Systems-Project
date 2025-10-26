using Microsoft.AspNetCore.Mvc;
using EntityFramework.Models;
using EntityFramework.Models.Interfaces;
using WebLayer.Dtos;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/titlesandgenres")]
public class TitleGenreController(MyDbContext context) : ControllerBase
{
    [HttpGet("{titleId}")]
    public ActionResult<TitleGenreDto> GetTitle(string titleId)
    {
        // Join TitleGenres -> Titles -> Genres to get names
        var query = from tg in context.TitleGenres
            join t in context.Titles on tg.Tconst equals t.Tconst
            join g in context.Genres on tg.GenreId equals g.GenreId
            where tg.Tconst == titleId
            select new { t.Originaltitle, g.GenreName };

        var list = query.ToList();

        if (!list.Any())
            return NotFound();

        // Build DTO
        var dto = new TitleGenreDto
        {
            TitleName = list.First().Originaltitle,             // all rows have same title
            Genres = list.Select(x => x.GenreName).ToList() // collect all genres
        };

        return Ok(dto);
    }
}