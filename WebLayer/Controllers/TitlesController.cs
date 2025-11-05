using EntityFramework.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebLayer.Dtos;
using EntityFramework;
using EntityFramework.DataServices;
using EntityFramework.Models;
using Mapster;
using MapsterMapper;

namespace WebLayer.Controllers;

[ApiController]
[Route("api/titles")]
public class TitlesController: BaseController<ITitleData>
{
    protected ITitleData _titleData => _dataService;
    
    public TitlesController(
        ITitleData titleData,
        LinkGenerator generator,
        IMapper mapper) : base(titleData, generator, mapper)
    {
    
    }

    [HttpGet(Name = nameof(GetTitles))] // GetTitles is the endpoint name, which is the IActionResult itself
                                        // that contains the host and path http://localhost:5001/api/titles
                                        // to build a URL
    public IActionResult GetTitles([FromQuery] QueryParams queryParams) //GetTitles here is the endpoint name
    {
        // queryParams.PageSize = Math.Min(queryParams.PageSize, 3);

        var titles = _titleData
            .GetTitles(queryParams) //GetTitles here is the method from TitleData
            .Select(x => CreateTitleDto(x));

        var numOfItems = _titleData.GetTitlesCount();
        
        var result = CreatePaging(nameof(GetTitles), titles, numOfItems, queryParams); 

        return Ok(result);
        
    }

    public ActionResult<IEnumerable<TitleDto>> GetAllTitles([FromQuery] QueryParams queryParams) //GetTitles here is the endpoint name
    {
        queryParams.PageSize = Math.Min(queryParams.PageSize, 3);

        var titles = _titleData.GetTitles(queryParams) //GetTitles here is the method from TitleData
            .Select(x => CreateTitleDto(x));

        var numOfItems = _titleData.GetTitlesCount();

        var result = CreatePaging(nameof(GetTitles), titles, numOfItems, queryParams);

        return Ok(result);
    }                                        
                                        
    [HttpGet("{id}", Name = nameof(GetTitleById))]
    public IActionResult GetTitleById(string id)
    {
        var title = _titleData.GetTitleById(id);

        if (title == null)
        {
            return NotFound();
        }

        var modeldto = CreateTitleDto(title);

        return Ok(modeldto);
    }
    
    
    private TitleDto CreateTitleDto(Title title)
    {
        var modeldto = _mapper.Map<TitleDto>(title); //Using MapsterMapper dependency injection
        modeldto.Url = GetUrl(nameof(GetTitleById), new { id = title.Tconst.Trim() }); // //GetTitles here is the endpoint name
        modeldto.TitleGenres = title.TitleGenres
            .Select(tg => tg.Genre.GenreName)
            .ToList();
        
        return modeldto;
    }
}