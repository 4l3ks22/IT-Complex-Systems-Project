using EntityFramework.Interfaces;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;


namespace EntityFramework.DataServices;

public class TitleGenreData(MyDbContext db) : ITitleGenreData
{
  
    
    public int GetTitleGenreCount()
    {
        return db.TitleGenres.Count(); 
    }
    public IList<TitleGenre> GetTitleGenre(QueryParams queryParams)
    {
        
        return db.TitleGenres
            
            .Include(x => x.Title)
            .Include(x => x.Genre)
            .OrderBy(x => x.Tconst)
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .ToList();
    }
    
    public IList<TitleGenre> GetTitleGenreById(string titleId)
    {
        return db.TitleGenres
            .Include(x => x.Title)
            .Include(x => x.Genre)
            .Where(x => x.Tconst == titleId)
            .ToList();;
    }
    
                //updates for frontend search
    //Implementing the interface to have genreId as parameter, similar to titleId as commented above (eg. # genre 4 Drama) and to obtain all titles related to that
    public IEnumerable<TitleGenre> GetTitlesByGenre(int genreId, QueryParams queryParams)
    {
        return db.TitleGenres
            .Where(tg => tg.GenreId == genreId)
            .Include(tg => tg.Title)//including Title model navigation variable in TitleGenre model
            .OrderBy(tg => tg.Tconst)
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .ToList();
    }
    
    //Implementing the interface to count the number of genreId (correspond to titles) to use in pagination of those titles linked to a genreId
    public int GetTitlesByGenreCount(int genreId)
    {
        return db.TitleGenres.Count(tg => tg.GenreId == genreId);
    }
}