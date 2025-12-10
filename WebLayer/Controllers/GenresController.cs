/*using EntityFramework.Interfaces;
using EntityFramework.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using WebLayer.Dtos;

namespace WebLayer.Controllers;

[ApiController]
[Route("api/genres")]
public class GenresController: BaseController<IGenreData> 
{
    protected IGenreData _genreData => _dataService;

    public GenresController(
        IGenreData genreData,
        LinkGenerator generator,
        IMapper mapper) : base(genreData, generator, mapper)
    {
    }

    [HttpGet(Name = nameof(GetGenres))]
    public ActionResult<IEnumerable<GenreDto>> GetGenres([FromQuery] QueryParams queryParams)
    {
        
        var genres =_genreData.GetGenres(queryParams).Select(x => CreateGenreDto(x));  //GetGenres here is the method from GenreData
        
        var numOfItems = _genreData.GetGenresCount();

        var result = CreatePaging(nameof(GetGenres), genres, numOfItems, queryParams);

        return Ok(result);
    }

    [HttpGet("{id}", Name = nameof(GetGenreById))]
    public IActionResult GetGenreById(int id)
    {
        var genre = _dataService.GetGenreById(id);

        if (genre == null)
        {
            return NotFound();
        }

        var modeldto = CreateGenreDto(genre);

        return Ok(modeldto);
    }
    
    
    private GenreDto CreateGenreDto(Genre genre)
    {
        var modeldto = _mapper.Map<GenreDto>(genre); //Using MapsterMapper dependency injection
        modeldto.Url = GetUrl(nameof(GetGenreById), new { id = genre.GenreId }); // //GetTitles here is the endpoint name
        return modeldto;
    }
    
}*/

//After update for frontend search
using EntityFramework.Interfaces;
using EntityFramework.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using WebLayer.Dtos;

namespace WebLayer.Controllers;

[ApiController]
[Route("api/genres")]
public class GenresController: BaseController<IGenreData> 
{
    protected IGenreData _genreData => _dataService;
    
    //With this, GenresController knows how to access the title-genre relationship table.
    private readonly ITitleGenreData _titleGenreData;

    public GenresController(
        IGenreData genreData,
        //With this, GenresController knows how to access the title-genre relationship table.
        ITitleGenreData titleGenreData,
        
        LinkGenerator generator,
        IMapper mapper) : base(genreData, generator, mapper)
    {
        //With this, GenresController knows how to access the title-genre relationship table.
        _titleGenreData = titleGenreData;
    }

    [HttpGet(Name = nameof(GetGenres))]
    public ActionResult<IEnumerable<GenreDto>> GetGenres([FromQuery] QueryParams queryParams)
    {
        
        var genres =_genreData.GetGenres(queryParams).Select(x => CreateGenreDto(x));  //GetGenres here is the method from GenreData
        
        var numOfItems = _genreData.GetGenresCount();

        var result = CreatePaging(nameof(GetGenres), genres, numOfItems, queryParams);

        return Ok(result);
    }

    [HttpGet("{id}", Name = nameof(GetGenreById))]
    public IActionResult GetGenreById(int id)
    {
        var genre = _dataService.GetGenreById(id);

        if (genre == null)
        {
            return NotFound();
        }

        var modeldto = CreateGenreDto(genre);

        return Ok(modeldto);
    }
    
    
    //Adding endpoint so then GenresController have access to TitleGenreData
    //because it is the one that contains the tconst to navigate to titles with titles controller and
    //Important to implement pagination for number of titles for genreId
    [HttpGet("{id}/titles", Name = nameof(GetTitlesByGenre))]
    public IActionResult GetTitlesByGenre(int id, [FromQuery] QueryParams queryParams)
    {
        var records = _titleGenreData.GetTitlesByGenre(id,queryParams );

        var results = records.Select(tg => new
        {
            url = GetUrl(nameof(TitlesController.GetTitleById), new { id = tg.Tconst.Trim() }),
            primarytitle = tg.Title.Primarytitle,
            startyear = tg.Title.Startyear
        })
        .ToList();
        
        var totalItems = _titleGenreData.GetTitlesByGenreCount(id);

        var result = CreatePaging(
            nameof(GetTitlesByGenre),
            results,
            totalItems,
            queryParams,
            new { id = id }   // This one is now required as it need to paginate including the search GenreId
        );

        return Ok(result);
        
    }
    
    private GenreDto CreateGenreDto(Genre genre)
    {
        var modeldto = _mapper.Map<GenreDto>(genre); //Using MapsterMapper dependency injection
        modeldto.Url = GetUrl(nameof(GetGenreById), new { id = genre.GenreId }); // //GetTitles here is the endpoint name
        return modeldto;
    }
    
  
}