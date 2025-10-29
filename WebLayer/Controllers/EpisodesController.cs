// using EntityFramework.Interfaces;
// using Microsoft.AspNetCore.Mvc;
// using EntityFramework.Models;
// using MapsterMapper;
// using Microsoft.EntityFrameworkCore.Diagnostics;
// using WebLayer.Dtos;
//
// namespace WebLayer.Controllers
// {
//     [ApiController]
//     [Route("api/episodes")]
//     public class EpisodesController : BaseController
//     {
//         public EpisodesController(
//             IEpisodeData episodeData,
//             LinkGenerator generator,
//             IMapper mapper) : base(episodeData, generator, mapper)
//         {
// }
//         
//         [HttpGet]
//         public ActionResult<List<EpisodeDto>> GetEpisodes()
//         {
//             var episodes = _episodeData.GetEpisodes();
//             return episodes.Select(e => new EpisodeDto
//             {
//                 Url = null, // Compute or set as required
//                 SeriesName = e.ParenttconstNavigation?.Primarytitle,
//                 Name = null,
//                 Season = e.Seasonnumber,
//                 Episode = e.Episodenumber
//             }).ToList();
//             ;
//         }
//         
//         [HttpGet("{tconst}",Name = nameof(GetEpisodeByID))]
//         public ActionResult<EpisodeDto> GetEpisodeByID(string tconst)
//         {
//             var episode = _episodeData.GetById(tconst);
//             var episodeDto = CreateEpisodeDto(episode);
//             return Ok(episodeDto);
//         }
//         private EpisodeDto CreateEpisodeDto(Episode episode)
//         {
//             return new EpisodeDto()
//             {
//                 Url = GetUrl(nameof(GetEpisodeByID), new { tconst = episode.Tconst }),
//                 SeriesName = episode.ParenttconstNavigation?.Primarytitle,
//                 Name = null,
//                 Season = episode.Seasonnumber,
//                 Episode = episode.Episodenumber
//             };
//         }
//
//         private string GetUrl(string endpointName,  object values)
//          {
//              return _generator.GetUriByName(HttpContext, endpointName, values );
//          }
//     }
// }