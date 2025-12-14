using EntityFramework.DataServices;
using EntityFramework.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebLayer.Dtos;

namespace WebLayer.Controllers;

[ApiController]
[Route("api/ratings")]
public class RatingsController : BaseController<IRatingData>
{
    protected IRatingData _ratingData => _dataService;

    public RatingsController(IRatingData ratingData) : base(ratingData, null, null)
    {
    }

    [Authorize]
    [HttpPost("rate")]
    public IActionResult Rate([FromBody] RateRequestDto dto)
    {
        if (dto == null || dto.Rating < 1 || dto.Rating > 10)
            return BadRequest("Invalid rating request");

        _ratingData.Rate(dto.UserId, dto.Tconst, dto.Rating);
        return Ok();
    }

    [Authorize]
    [HttpGet("{userId}")]
    public ActionResult<List<UserRatingDto>> GetUserRatings(int userId)
    {
        var ratings = _ratingData.GetUserRating(userId)
            .Where(r => r.TconstNavigation != null && r.Rating.HasValue)
            .Select(r => new UserRatingDto
            {
                TitleName = r.TconstNavigation!.Primarytitle,
                Rating = r.Rating!.Value
            })
            .ToList();

        return Ok(ratings);
    }
}