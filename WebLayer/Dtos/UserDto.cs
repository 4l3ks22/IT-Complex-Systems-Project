namespace WebLayer.Dtos;

public class UserDto
{
    public string? Url {get; set;}
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!; 

    public DateTime? CreationTime { get; set; }

}
