namespace EntityFramework.Models.Interfaces;

public interface ITitleGenreData
{
    List<TitleGenre> GetTitleGenres();
    
    List<TitleGenre> GetTitleGenresByTitleId(string titleId);
}