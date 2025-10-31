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
    

    /*[HttpGet("{titleId}")]
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
    }*/
    
    [HttpGet(Name = nameof(GetTitleGenre))]
    public IActionResult GetTitleGenre([FromQuery] QueryParams queryParams)
    {
        // queryParams.PageSize = Math.Min(queryParams.PageSize, 3);

        var titlegenre = _titlegenreData
            .GetTitleGenre(queryParams.PageNumber, queryParams.PageSize)
            .Select(x => CreateTitleGenreDto(x));

        var numOfItems = _titlegenreData.GetTitleGenreCount();
        
        var result = CreatePaging(nameof(GetTitleGenre), titlegenre, numOfItems, queryParams); 

        return Ok(result);
    }

    [HttpGet("{id}", Name = nameof(GetTitleGenreById))]
    public IActionResult GetTitleGenreById(string titleId)
    {
        var titlegenre = _titlegenreData.GetTitleGenreById(titleId);

        if (titlegenre == null)
        {
            return NotFound();
        }

        var modeldto = CreateTitleGenreDto(titlegenre);

        return Ok(modeldto);
    }

    
    private TitleGenreDto CreateTitleGenreDto(TitleGenre titleGenre)
    {
        var modeldto = _mapper.Map<TitleGenreDto>(titleGenre); //Using MapsterMapper dependency injection
        modeldto.Url = GetUrl(nameof(GetTitleGenreById), new { id = titleGenre.Tconst}); // //GetTitles here is the endpoint name
        
        return modeldto;
    }
    
}