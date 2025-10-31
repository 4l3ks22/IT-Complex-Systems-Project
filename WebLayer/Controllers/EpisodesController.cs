using EntityFramework.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EntityFramework.Models;
using MapsterMapper;
using Mapster;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebLayer.Dtos;

namespace WebLayer.Controllers
{
    /*[ApiController]
    [Route("api/episodes")]
    public class EpisodesController : BaseController
    {
        public EpisodesController(
            IEpisodeData episodeData,
            LinkGenerator generator,
            IMapper mapper) : base(episodeData, generator, mapper)
        {
}

        [HttpGet]
        public ActionResult<List<EpisodeDto>> GetEpisodes()
        {
            var episodes = _episodeData.GetEpisodes();
            return episodes.Select(e => new EpisodeDto
            {
                Url = null, // Compute or set as required
                SeriesName = e.ParenttconstNavigation?.Primarytitle,
                Name = null,
                Season = e.Seasonnumber,
                Episode = e.Episodenumber
            }).ToList();
            ;
        }

        [HttpGet("{tconst}",Name = nameof(GetEpisodeByID))]
        public ActionResult<EpisodeDto> GetEpisodeByID(string tconst)
        {
            var episode = _episodeData.GetById(tconst);
            var episodeDto = CreateEpisodeDto(episode);
            return Ok(episodeDto);
        }
        private EpisodeDto CreateEpisodeDto(Episode episode)
        {
            return new EpisodeDto()
            {
                Url = GetUrl(nameof(GetEpisodeByID), new { tconst = episode.Tconst }),
                SeriesName = episode.ParenttconstNavigation?.Primarytitle,
                Name = null,
                Season = episode.Seasonnumber,
                Episode = episode.Episodenumber
            };
        }

        private string GetUrl(string endpointName,  object values)
         {
             return _generator.GetUriByName(HttpContext, endpointName, values );
         }
    }*/
    
    //This approach was working but a little wrong 31-10-2025 5:37pm, because seriename and titleurl = null
    /*[ApiController]
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

        [HttpGet(Name = nameof(GetEpisodes))] // GetTitles is the endpoint name, which is the IActionResult itself
        // that contains the host and path http://localhost:5001/api/titles
        // to build a URL
        public IActionResult GetEpisodes([FromQuery] QueryParams queryParams) //GetTitles here is the endpoint name
        {
            queryParams.PageSize = Math.Min(queryParams.PageSize, 3);

            var titles = _episodeData
                .GetEpisodes(queryParams.Page, queryParams.PageSize) //GetTitles here is the method from TitleData
                .Select(x => CreateEpisodeDto(x));

            var numOfItems = _episodeData.GetEpisodesCount();

            var result = CreatePaging(nameof(GetEpisodes), titles, numOfItems, queryParams);

            return Ok(result);

        }

        [HttpGet("{id}", Name = nameof(GetEpisodesById))]
        public IActionResult GetEpisodesById(string id)
        {
            var episodes = _episodeData.GetEpisodesById(id);

            if (episodes == null)
            {
                return NotFound();
            }

            var modeldto = CreateEpisodeDto(episodes);

            return Ok(modeldto);
        }

        private EpisodeDto CreateEpisodeDto(Episode episode)
        {
            var modeldto = _mapper.Map<EpisodeDto>(episode); //Using MapsterMapper dependency injection
            modeldto.Url = GetUrl(nameof(GetEpisodesById), new { id = episode.Tconst }); // //GetTitles here is the endpoint name
            //modeldto.Url = GetUrl(nameof(GetEpisodesById), new { id = episode.Parenttconst });
            modeldto.TitleUrl = GetUrl(nameof(TitlesController.GetTitleById), new { episode.ParenttconstNavigation.Tconst }); // added by cesar
            
            return modeldto;
        }
        
    }*/
    
    
    // last updated working version 31-10-2025 19:00pm
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
            // queryParams.PageSize = Math.Min(queryParams.PageSize, 3);

            var episodes = _episodeData
                .GetEpisodes(queryParams.PageNumber, queryParams.PageSize)
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
            modeldto.Url = GetUrl(nameof(GetEpisodesById), new { id = episode.Tconst.Trim() });

            // Building the related Title URL 

            modeldto.TitleUrl = GetUrl(
                nameof(TitlesController.GetTitleById),
                new { id = episode.ParenttconstNavigation.Tconst.Trim() }); 
            
            return modeldto;
        }
    }
}
    
    


