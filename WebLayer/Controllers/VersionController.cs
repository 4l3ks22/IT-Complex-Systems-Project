using EntityFramework.Interfaces;
using EntityFramework.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using WebLayer.Dtos;
using Version = EntityFramework.Models.Version;

namespace WebLayer.Controllers;

[Route("api/versions")]

public class VersionController : BaseController<IVersionData>
{
    protected IVersionData _versionData => _dataService;
    
    public VersionController(IVersionData dataService, LinkGenerator generator, IMapper mapper) : base(dataService, generator, mapper)
    {
    }
    
    [HttpGet(Name = nameof(GetVersions))]
    
    public IActionResult GetVersions([FromQuery] QueryParams queryParams)
    {
        
        var versions = _versionData
            .GetVersions(queryParams)
            .Select(x => CreateVersionDto(x));

        var numOfItems = versions.Count();
        
        var result = CreatePaging(nameof(GetVersions), versions, numOfItems, queryParams);
        
        return Ok(versions);
    }


    public VersionDto CreateVersionDto(Version version)
    {
        var modeldto = _mapper.Map<VersionDto>(version);
        return modeldto;
    }
}