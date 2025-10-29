using EntityFramework.Interfaces;
using EntityFramework.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using WebLayer.Dtos;

namespace WebLayer.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : BaseController<IUserData>
{
protected IUserData _userData => _dataService;
    
public UserController(
    IUserData userData,
    LinkGenerator generator,
    IMapper mapper) : base(userData, generator, mapper)
{
    
}
[HttpGet(Name = nameof(GetUsers))]
public ActionResult<IEnumerable<UserDto>> GetUsers([FromQuery] QueryParams queryParams)
{
    queryParams.PageSize = Math.Min(queryParams.PageSize, 3);

    var users = _userData.GetUsers(queryParams.Page, queryParams.PageSize) .Select(x => CreateUsersDto(x));

    var numOfItems = _userData.GetUsersCount();

    var result = CreatePaging(nameof(GetUsers), users, numOfItems, queryParams);

    return Ok(result);
}

[HttpGet("{userId}", Name = nameof(GetUserById))]
public IActionResult GetUserById(int userId)
{
var user = _userData.GetUserById(userId);
return Ok(CreateUsersDto(user));
}
private UserDto CreateUsersDto(User user)
{
    var modeldto = _mapper.Map<UserDto>(user); //Using MapsterMapper dependency injection
    modeldto.Url = GetUrl(nameof(GetUserById),new{userId = user.UserId});
    return modeldto;
}
 }