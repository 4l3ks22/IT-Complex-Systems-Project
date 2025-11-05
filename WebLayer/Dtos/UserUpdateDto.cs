using System.ComponentModel.DataAnnotations;

namespace WebLayer.Dtos;

public class UserUpdateDto
{
    [StringLength(40, MinimumLength = 5, ErrorMessage = "Username cannot be changed")]
    public string Username { get; set; }
    
    public string Email { get; set; }
    
    [StringLength(25, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 25 characters")]
    public string PasswordHash { get; set; }
}