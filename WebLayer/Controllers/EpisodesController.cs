using Microsoft.AspNetCore.Mvc;
using EntityFramework.Models;
using EntityFramework.Models.Interfaces;
using WebLayer.Dtos;

namespace WebLayer.Controllers
{
    [ApiController]
    [Route("api/episodes")]
    public class EpisodesController(IEpisodeData episodeData) : ControllerBase
    {
        
        [HttpGet]
        public ActionResult<IEnumerable<Episode>> getEpisodes()
        {
            var episodes = episodeData.GetEpisodes();

            var dtos = episodes.Select(e => new EpisodeDto()
            {
                Season = e.Seasonnumber,
                Episode = e.Episodenumber
            }).ToList();

            return Ok(dtos);
        }
    }
}