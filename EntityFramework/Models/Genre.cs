using EntityFramework.Models;

public class Genre
{
    public int GenreId { get; set; }
    public string GenreName { get; set; } = null!;

    public virtual ICollection<TitleGenre> TitleGenres { get; set; } = new List<TitleGenre>();

    // Convenience navigation to Titles
    public virtual ICollection<Title> Titles => TitleGenres.Select(tg => tg.Title).ToList();
}