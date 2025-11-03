using System.ComponentModel.DataAnnotations;

namespace WebLayer.Dtos;

public class UserCreationDto
{
    [Required(ErrorMessage = "Username is required")]
    [StringLength(40, MinimumLength = 5, ErrorMessage = "Username must be between 3 and 40 characters")]
    public string UserName { get; set; }
    
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [StringLength(25, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 25 characters")]
    public string Password { get; set; }
}
