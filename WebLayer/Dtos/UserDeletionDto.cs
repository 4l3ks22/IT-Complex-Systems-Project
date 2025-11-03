using System.ComponentModel.DataAnnotations;

namespace WebLayer.Dtos;

public class UserDeletionDto
{
    [Required(ErrorMessage = "ID is required")]
    public string UserId { get; set; } = null!;
}