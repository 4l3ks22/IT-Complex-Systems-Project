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

[HttpPost(Name = nameof(CreateUser))]
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

// [HttpPost( Name = nameof(LoginUser))]
// public IActionResult LoginUser([FromBody] LoginRequestDto loginRequestDto)
// {
//     if (loginRequestDto == null)
//     {
//         return BadRequest("User object is null");
//     }
//     
//     var user = _userData.LoginUser(loginRequestDto.Username, loginRequestDto.Password);
//     if (user == null)
//         return BadRequest("Invalid username or password");
//     return Ok(user);
// }

[HttpDelete("{UserId}")]
public IActionResult DeleteUser(int UserId)
{
    if (_userData.GetUserById(UserId) == null)
    {
        return BadRequest("Wrong ID or user does not exist");
    }
    var user = _userData.GetUserById(UserId);
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
 