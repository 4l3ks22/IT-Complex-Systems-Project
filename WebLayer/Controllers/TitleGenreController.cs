using EntityFramework;
using Microsoft.AspNetCore.Mvc;
using EntityFramework.Models;
using WebLayer.Dtos;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/titlesandgenres")]
public class TitleGenreController(MyDbContext context) : ControllerBase
{
    [HttpGet("{titleId}")]
    public ActionResult<TitleGenreDto> GetTitle(string titleId)
    {
        var title = context.Titles
            .Include(t => t.TitleGenres)
            .ThenInclude(tg => tg.Genre)
            .FirstOrDefault(t => t.Tconst == titleId);

        if (title == null)
            return NotFound();

        var dto = new TitleGenreDto
        {
            TitleName = title.Originaltitle,
            Genres = title.TitleGenres.Select(tg => tg.Genre.GenreName).ToList()
        };

        return Ok(dto);
    }
}