using EntityFramework.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebLayer.Dtos;
using EntityFramework;
using EntityFramework.DataServices;
using EntityFramework.Models;
using Mapster;
using MapsterMapper;

namespace WebLayer.Controllers;

[Route("api/bookmarks")]
public class BookmarkController : BaseController<IBookmarkData>
{
    protected IBookmarkData _bookmarkData => _dataService;

    public BookmarkController(IBookmarkData bookmarkData, LinkGenerator generator,
        IMapper mapper) : base(bookmarkData, generator, mapper)
    {
        
    }

[HttpGet(Name = nameof(GetBookmarks))]

    public IActionResult GetBookmarks([FromQuery] QueryParams queryParams)
    {
        var bookmarks = _bookmarkData.GetAllBookmarks(queryParams).Select(x => CreateBookmarkDto(x));
        var numOfItems = _bookmarkData.GetBookmarksCount();
        var result = CreatePaging(nameof(GetBookmarks), bookmarks, numOfItems, queryParams);
        return Ok(result);
    } 
    
[HttpGet("{userId}", Name = nameof(GetBookmarksByUserId))]
    public IActionResult GetBookmarksByUserId([FromQuery]QueryParams queryParams, int userId)
    {
        var bookmarks = _bookmarkData.GetBookmarksByUserId(queryParams,userId).Select(x => CreateBookmarkDto(x))
            .ToList();;
        var numOfItems = _bookmarkData.GetBookmarksCountByUserId(userId);
        
        var result = CreatePaging(nameof(GetBookmarksByUserId), bookmarks, numOfItems, queryParams);
        
        return Ok(result);
    }             
    
    private BookmarkDto CreateBookmarkDto(UserBookmark userBookmark)
    {
        var modelDto = _mapper.Map<BookmarkDto>(userBookmark);
        return modelDto;
    }

    [HttpPost(Name = nameof(CreateUserBookmark))]
    public IActionResult CreateUserBookmark([FromBody] CreateBookmarkDto createBookmarkDto)
    {
        if (createBookmarkDto == null)
            return BadRequest("Bookmark object is null");
        var bookmark = createBookmarkDto.Adapt<UserBookmark>();
        _bookmarkData.AddUserBookmark(bookmark);
        return Ok(); //needs to be changed with CreatedAtRoute
    }
    
    [HttpDelete(Name = nameof(DeleteUserBookmark))]

    public IActionResult DeleteUserBookmark([FromBody] DeleteBookmarkDto deleteBookmarkDto)
    {
        if (deleteBookmarkDto == null)
            return BadRequest("Bookmark object is null");

        var bookmark = _bookmarkData.GetBookmarkById(deleteBookmarkDto.BookmarkId);
            
        if (bookmark != null)
        {
            _bookmarkData.DeleteUserBookmark(bookmark);
            return NoContent();
        }
        return NotFound();
    }
    
}        
