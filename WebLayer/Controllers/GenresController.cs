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
    
  
}