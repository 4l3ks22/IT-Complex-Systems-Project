using EntityFramework.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebLayer.Dtos;
using EntityFramework;
using EntityFramework.Models;
using Mapster;
using MapsterMapper;

namespace WebLayer.Controllers;


/*
[ApiController]
[Route("api/titles")]
public class TitlesController(ITitleData titleData): ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<TitleDto>> GetTitles()
    {
        var titles = titleData.GetTitles();
        var titleDtos = titles
            .Select(t => new TitleDto
        {
            PrimaryName = t.Primarytitle,
            OriginalName = t.Originaltitle,
            Type = t.Titletype,
            IsAdult = t.Isadult,
            StartYear = t.Startyear,
            EndYear = t.Endyear,
            RuntimeMinutes = t.Runtimeminutes,
            
        })
            .ToList();
        
        return Ok(titleDtos);
    }
}*/

[ApiController]
[Route("api/titles")]
public class TitlesController: BaseController
{
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
        queryParams.PageSize = Math.Min(queryParams.PageSize, 3);

        var titles = _titleData.GetTitles(queryParams.Page, queryParams.PageSize) //GetTitles here is the method from TitleData
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

        
    
    [HttpPost]
    public IActionResult CreateTitle(TitleDto creationdto) // CreateTitleModel should be an extra Dto
    {
        var title  = creationdto.Adapt<Title>(); // using Mapster with Adapt

        _titleData.CreateTitle(title);

        return Created();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTitle(string tconst)
    {
        if (_titleData.DeleteTitle(tconst))
        {
            return NoContent();
        }

        return NotFound();
    }

    private TitleDto CreateTitleDto(Title title)
    {
        var modeldto = _mapper.Map<TitleDto>(title); //Using MapsterMapper dependency injection
        modeldto.Url = GetUrl(nameof(GetTitleById), new { id = title.Tconst }); // //GetTitles here is the endpoint name
        return modeldto;
    }
}