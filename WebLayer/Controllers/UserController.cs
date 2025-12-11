using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EntityFramework.DataServices;
using EntityFramework.Interfaces;
using EntityFramework.Models;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebLayer.Dtos;

namespace WebLayer.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : BaseController<IUserData>
{
    private readonly IConfiguration _configuration;
    protected IUserData _userData => _dataService;

    public UserController(
        IUserData userData,
        LinkGenerator generator,
        IMapper mapper,
        IConfiguration configuration
    ) : base(userData, generator, mapper)
    {
        _configuration = configuration;
    }
    
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestDto loginRequestDto)
    {
        if (loginRequestDto == null)
            return BadRequest("Invalid login request");

        var user = _userData.LoginUser(loginRequestDto.Email, loginRequestDto.Password);
        if (user == null)
            return Unauthorized("Invalid email or password");

        var token = GenerateJwtToken(user);
        return Ok(new
        {
            Token = token,
            UserId = user.UserId,      
            Email = user.Email,
            Username = user.Username
        });
    }
    
    private string GenerateJwtToken(User user)
    {
        var jwtSettings = _configuration.GetSection("Jwt");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("UserId", user.UserId.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    [HttpGet(Name = nameof(GetUsers))]
    public ActionResult<IEnumerable<UserDto>> GetUsers([FromQuery] QueryParams queryParams)
    {
        var users = _userData.GetUsers(queryParams)
            .Select(CreateUsersDto);

        var numOfItems = _userData.GetUsersCount();
        var result = CreatePaging(nameof(GetUsers), users, numOfItems, queryParams);
        return Ok(result);
    }
    
    [Authorize]
    [HttpGet("{userId}", Name = nameof(GetUserById))]
    public IActionResult GetUserById(int userId)
    {
        var user = _userData.GetUserById(userId);
        if (user == null)
            return NotFound("User not found");

        return Ok(CreateUsersDto(user));
    }

    [HttpPost(Name = nameof(CreateUser))]
    public IActionResult CreateUser([FromBody] UserCreationDto userCreationDto)
    {
        if (userCreationDto == null)
            return BadRequest("User object is null");

        var user = userCreationDto.Adapt<User>();
        _userData.AddUser(user);

        return CreatedAtRoute(nameof(GetUserById), new { userId = user.UserId }, CreateUsersDto(user));
    }

    [Authorize]
    [HttpPut("{userId}")]
    public IActionResult UpdateUser(int userId, [FromBody] UserUpdateDto userUpdateDto)
    {
        var existingUser = _userData.GetUserById(userId);
        if (existingUser == null)
            return NotFound("User not found");

        // Update only changed fields
        if (!string.IsNullOrEmpty(userUpdateDto.Email))
            existingUser.Email = userUpdateDto.Email;

        if (!string.IsNullOrEmpty(userUpdateDto.PasswordHash))
            existingUser.PasswordHash = PasswordHasher.Hash(userUpdateDto.PasswordHash);

        _userData.UpdateUser(existingUser);
        return NoContent();
    }
    
    [HttpDelete("{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        var user = _userData.GetUserById(userId);
        if (user == null)
            return NotFound("User not found");

        _userData.DeleteUser(user);
        return NoContent();
    }
    
    
    // Added user bookmarks endpoint
    [Authorize]
    [HttpGet("{userId}/bookmarks")]
    public IActionResult GetUserBookmarks(int userId)
    {
        // Check if user exists
        var user = _userData.GetUserById(userId);
        if (user == null)
            return NotFound("User not found");

        // Verify the current user is accessing their own bookmarks
        var currentUserId = int.Parse(User.FindFirst("UserId")?.Value ?? "0");
        if (currentUserId != userId)
            return Forbid("You can only access your own bookmarks");

        // Get user's bookmarks with title/person information
        var bookmarks = _userData.GetUserBookmarksWithDetails(userId);
        if (bookmarks == null || !bookmarks.Any())
            return NotFound("No bookmarks found");

        var response = new UserBookmarksResponseDto
        {
            UserId = userId,
            Username = user.Username,
            Bookmarks = bookmarks.Select(b => new UserBookmarkDto
            {
                BookmarkId = b.BookmarkId,
                Title = b.TconstNavigation?.Primarytitle,
                PersonName = b.NconstNavigation?.Primaryname,
                Tconst = b.Tconst,
                Nconst = b.Nconst,
                BookmarkTime = b.BookmarkTime ?? DateTime.UtcNow
            })
        };

        return Ok(response);
    }


    // Create DTO method
    private UserDto CreateUsersDto(User user)
    {
        var modelDto = _mapper.Map<UserDto>(user);
        modelDto.Url = GetUrl(nameof(GetUserById), new { userId = user.UserId });
        return modelDto;
    }
}