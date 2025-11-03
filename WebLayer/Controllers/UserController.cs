using EntityFramework.Interfaces;
using EntityFramework.Models;
using Mapster;
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
    var users = _userData.GetUsers(queryParams) .Select(x => CreateUsersDto(x));

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

[HttpPost]
public IActionResult CreateUser ([FromBody]UserCreationDto userCreationDto)
{
    if (userCreationDto == null)
    {
        return BadRequest("Owner object is null");
    }
    var user = userCreationDto.Adapt<User>();
    _userData.AddUser(user);
    return Created();
}
[HttpDelete("{UserId}")]
public IActionResult DeleteUser([FromBody] UserDeletionDto userDeletionDto)
{
    if (userDeletionDto == null)
    {
        return BadRequest("Wrong ID or user does not exist");
    }
    var user = userDeletionDto.Adapt<User>();
    _userData.GetUserById(user.UserId);
    _userData.DeleteUser(user);
    return NoContent();
}

private UserDto CreateUsersDto(User user)
{
    var modeldto = _mapper.Map<UserDto>(user); //Using MapsterMapper dependency injection
    modeldto.Url = GetUrl(nameof(GetUserById),new{userId = user.UserId});
    return modeldto;
}
}
 