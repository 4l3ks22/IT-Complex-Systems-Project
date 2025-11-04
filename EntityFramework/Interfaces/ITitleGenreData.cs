using EntityFramework.Models;

namespace EntityFramework.Interfaces;

public interface ITitleGenreData
{
    
    int GetTitleGenreCount();
    public IList<TitleGenre> GetTitleGenre(QueryParams queryParams);
    IList<TitleGenre> GetTitleGenreById(string titleId);
}



