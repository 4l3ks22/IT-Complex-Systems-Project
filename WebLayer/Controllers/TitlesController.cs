using EntityFramework.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebLayer.Dtos;

namespace WebLayer.Controllers;



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
}