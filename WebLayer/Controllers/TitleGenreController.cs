// using EntityFramework;
// using EntityFramework.Interfaces;
// using Microsoft.AspNetCore.Mvc;
// using EntityFramework.Models;
// using MapsterMapper;
// using WebLayer.Controllers;
// using WebLayer.Dtos;
//
// [ApiController]
// [Route("api/titlesandgenres")]
// public class TitleGenreController : BaseController<ITitleGenreData>
// {
//     protected ITitleGenreData _titlegenreData => _dataService;
//     
//     public TitleGenreController(
//         ITitleData titlegenreData,
//         LinkGenerator generator,
//         IMapper mapper) : base(titlegenreData, generator, mapper)
//     {
//     
//     }
//     
// {
//     /*[HttpGet("{titleId}")]
//     public ActionResult<TitleGenreDto> GetTitle(string titleId)
//     {
//         var title = context.Titles
//             .Include(t => t.TitleGenres)
//             .ThenInclude(tg => tg.Genre)
//             .FirstOrDefault(t => t.Tconst == titleId);
//
//         if (title == null)
//             return NotFound();
//
//         var dto = new TitleGenreDto
//         {
//             TitleName = title.Originaltitle,
//             Genres = title.TitleGenres.Select(tg => tg.Genre.GenreName).ToList()
//         };
//
//         return Ok(dto);
//     }*/
//     
//     [HttpGet(Name = nameof(GetTitleGenre))]
//     public IActionResult GetTitleGenre([FromQuery] QueryParams queryParams)
//     {
//         queryParams.PageSize = Math.Min(queryParams.PageSize, 3);
//
//         var titlegenre = _titlegenreData
//             .GetTitleGenre(queryParams.Page, queryParams.PageSize) //GetTitles here is the method from TitleData
//             .Select(x => CreateTitleGenreDto(x));
//
//         var numOfItems = _titlegenreData.GetTitleGenreCount();
//         
//         var result = CreatePaging(nameof(GetTitleGenre), titlegenre, numOfItems, queryParams); 
//
//         return Ok(result);
//     }
//
//     [HttpGet("{id}", Name = nameof(GetTitleGenreById))]
//     public IActionResult GetTitleGenreById(string tconst, int genreId)
//     {
//         var titlegenre = _titlegenreData.GetTitleGenreById(tconst, genreId);
//
//         if (titlegenre == null)
//         {
//             return NotFound();
//         }
//
//         var modeldto = CreateTitleGenreDto(titlegenre);
//
//         return Ok(modeldto);
//     }
//
//     
//     private TitleGenreDto CreateTitleGenreDto()
//     {
//         var modeldto = _mapper.Map<TitleDto>(); //Using MapsterMapper dependency injection
//         modeldto.Url = GetUrl(nameof(GetTitleGenreById), new { id =  }); // //GetTitles here is the endpoint name
//         
//         return modeldto;
//     }
//     
//     
//     
//     
// }