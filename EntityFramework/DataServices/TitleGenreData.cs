using EntityFramework.Interfaces;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;


namespace EntityFramework.DataServices;

public class TitleGenreData(MyDbContext db) : ITitleGenreData
{
  
    
    public int GetTitleGenreCount()
    {
        return db.TitleGenres.Count(); // TitlesGenres is from MyDbContext
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
}