namespace WebLayer.Dtos;

public class UserDto
{
    public string? Url {get; set;}
    
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!; 

    public DateTime? CreationTime { get; set; }

}

// Added user bookmark dtos - one for each bookmark and one for the response containing user info and list of bookmarks 

public class UserBookmarkDto
{
    public int BookmarkId { get; set; }
    public string Title { get; set; }
    public string PersonName { get; set; }
    public string Tconst { get; set; }
    public string Nconst { get; set; }
    public DateTime BookmarkTime { get; set; }
}

public class UserBookmarksResponseDto
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public IEnumerable<UserBookmarkDto> Bookmarks { get; set; }
}
