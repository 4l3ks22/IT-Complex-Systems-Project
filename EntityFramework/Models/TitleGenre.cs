namespace EntityFramework.Models;

public class TitleGenre
{
    public required string Tconst { get; set; }
    public required int GenreId { get; set; }
    
    public Title Title { get; set; }
    
    public Genre Genre { get; set; }
}