using EntityFramework.Models;

namespace EntityFramework.Interfaces;

public interface ITitleGenreData
{
    /*List<TitleGenre> GetTitleGenres();
    
    List<TitleGenre> GetTitleGenresByTitleId(string titleId);*/


    int GetTitleGenreCount();
    public IList<TitleGenre> GetTitleGenre(int page, int pageSize);
    TitleGenre? GetTitleGenreById(string titleId); 
}

