using EntityFramework.Interfaces;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;


namespace EntityFramework.DataServices;

public class TitleGenreData(MyDbContext db) : ITitleGenreData
{
    /*public List<TitleGenre> GetTitleGenres()
    {
        return db.TitleGenres
            .ToList();
    }

    public List<TitleGenre> GetTitleGenresByTitleId(string titleId)
    {
        return db.TitleGenres
            .Where(tg => tg.Tconst == titleId)
            .ToList();
    }*/
    
    
    public int GetTitleGenreCount()
    {
        return db.TitleGenres.Count(); // Titles is from MyDbContext
    }
    public IList<TitleGenre> GetTitleGenre(int page, int pageSize)
    {
        
        return db.TitleGenres
            //.Include(t => t.Genres)
            .OrderBy(x => x.Tconst)
            .Skip(page* pageSize)
            .Take(pageSize)
            .ToList();
    }
    
    public TitleGenre? GetTitleGenreById(string titleId)
    {
        return db.TitleGenres.FirstOrDefault(x => x.Tconst == titleId );
    }
}