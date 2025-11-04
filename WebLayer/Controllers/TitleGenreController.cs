using EntityFramework;
using EntityFramework.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EntityFramework.Models;
using MapsterMapper;
using WebLayer.Controllers;
using WebLayer.Dtos;

[ApiController]
[Route("api/titlegenre")]
public class TitleGenreController : BaseController<ITitleGenreData>
{
    protected ITitleGenreData _titlegenreData => _dataService;
    
    public TitleGenreController(
        ITitleGenreData titlegenreData,
        LinkGenerator generator,
        IMapper mapper) : base(titlegenreData, generator, mapper)
    {
    
    }
    
    
    [HttpGet(Name = nameof(GetTitleGenre))]
    public IActionResult GetTitleGenre([FromQuery] QueryParams queryParams)
    {
        var data = _titlegenreData
            .GetTitleGenre(queryParams)
            .GroupBy(x => x.Tconst)
            .Select(g => new TitleGenreDto
            {
                Url = GetUrl(nameof(GetTitleGenreById), new { id = g.Key }),
                Tconst = g.Key,
                Title = g.First().Title.Primarytitle ?? "",
                Genres = g.Select(x => x.Genre.GenreName).Distinct().ToList()
            });

        var numOfItems = _titlegenreData.GetTitleGenreCount();
        var result = CreatePaging(nameof(GetTitleGenre), data, numOfItems, queryParams);
        return Ok(result);
    }

    [HttpGet("{id}", Name = nameof(GetTitleGenreById))]
    public IActionResult GetTitleGenreById(string id)
    {
        var records = _titlegenreData
            .GetTitleGenreById(id);
            

        if (!records.Any())
            return NotFound();

        var modeldto = new TitleGenreDto
        {
            Url = GetUrl(nameof(GetTitleGenreById), new { id }),
            Tconst = id,
            Title = records.First().Title.Primarytitle ?? "",
            Genres = records.Select(x => x.Genre.GenreName).Distinct().ToList()
        };

        return Ok(modeldto);
    }
    
}