// csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EntityFramework.Models.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class EpisodesController(IEpisodeData episodes) : ControllerBase
{
    
}