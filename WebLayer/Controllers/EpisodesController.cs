using EntityFramework.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EntityFramework.Models;
using MapsterMapper;
using Mapster;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebLayer.Dtos;

namespace WebLayer.Controllers
{
    [ApiController]
    [Route("api/episodes")]
    public class EpisodesController : BaseController<IEpisodeData>
    {
        protected IEpisodeData _episodeData => _dataService;

        public EpisodesController(
            IEpisodeData episodeData,
            LinkGenerator generator,
            IMapper mapper) : base(episodeData, generator, mapper)
        {
        }

        [HttpGet(Name = nameof(GetEpisodes))]
        public IActionResult GetEpisodes([FromQuery] QueryParams queryParams)
        {

            var episodes = _episodeData
                .GetEpisodes(queryParams)
                .Select(x => CreateEpisodeDto(x));

            var numOfItems = _episodeData.GetEpisodesCount();

            var result = CreatePaging(nameof(GetEpisodes), episodes, numOfItems, queryParams);

            return Ok(result);
        }

        [HttpGet("{id}", Name = nameof(GetEpisodesById))]
        public IActionResult GetEpisodesById(string id)
        {
            var episode = _episodeData.GetEpisodesById(id);

            if (episode == null)
                return NotFound();

            var modeldto = CreateEpisodeDto(episode);
            return Ok(modeldto);
        }
        
        
        private EpisodeDto CreateEpisodeDto(Episode episode)
        {
            var modeldto = _mapper.Map<EpisodeDto>(episode); 

            // Building the episode’s own URL  using LinkGenerator
            modeldto.EpisodeUrl = GetUrl(nameof(GetEpisodesById), new { id = episode.Tconst.Trim() });

            // Building the related Title URL 

            modeldto.SerieUrl = GetUrl(
                nameof(TitlesController.GetTitleById),
                new { id = episode.ParenttconstNavigation.Tconst.Trim() }); 
            
            return modeldto;
        }
    }
}
    
    


