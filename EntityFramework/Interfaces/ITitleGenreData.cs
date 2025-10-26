using EntityFramework.Models;

namespace EntityFramework.Interfaces;

public interface ITitleGenreData
{
    List<TitleGenre> GetTitleGenres();
    
    List<TitleGenre> GetTitleGenresByTitleId(string titleId);
}