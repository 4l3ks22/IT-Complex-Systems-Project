using EntityFramework.Models;

namespace EntityFramework.Interfaces;

public interface ITitleGenreData
{
    
    int GetTitleGenreCount();
    public IList<TitleGenre> GetTitleGenre(QueryParams queryParams);
    IList<TitleGenre> GetTitleGenreById(string titleId);
    
            //Updates for frontend search
    //Creating an interface to have genreId as parameter (eg. # 4 Drama) and to obtain all titles related to that
    IEnumerable<TitleGenre> GetTitlesByGenre(int genreId, QueryParams queryParams);
    
    
    //Interface useful to implement pagination for number of titles for genreId
    int GetTitlesByGenreCount(int genreId);
}



