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
    
    [HttpGet("{titleId}", Name = nameof(GetVersions))]
    
    public IActionResult GetVersions([FromQuery] QueryParams queryParams, string titleId)
    {

        var versions = _versionData
            .GetVersions(queryParams, titleId)
            .Select(x => CreateVersionDto(x))
            .ToList();

        var numOfItems = _versionData.GetVersionsCount(titleId);
        
        var result = CreatePaging(nameof(GetVersions), versions, numOfItems, queryParams);
        
        return Ok(result);
    }
    

    public VersionDto CreateVersionDto(Version version)
    {
        var modeldto = _mapper.Map<VersionDto>(version);
        
        return modeldto;
    }
}