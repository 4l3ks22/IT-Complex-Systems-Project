namespace WebLayer.Dtos;

public class BookmarkDto
{
    public int BookmarkId { get; set; }

    public int? UserId { get; set; }

    public string? Tconst { get; set; }

    public string? Nconst { get; set; }

    public DateTime? BookmarkTime { get; set; } 
}