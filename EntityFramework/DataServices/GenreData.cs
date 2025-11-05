using EntityFramework.Interfaces;
using EntityFramework.Models;


namespace EntityFramework.DataServices;

public class GenreData(MyDbContext db) : IGenreData 
{
    public int GetGenresCount()
    {
        return db.Genres.Count(); 
    }


    public IList<Genre> GetGenres(QueryParams queryParams)
    {
        
        return db.Genres
            .OrderBy(x => x.GenreId)
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .ToList();
    }
    
    public Genre? GetGenreById(int genreId)
    {
        return db.Genres.FirstOrDefault(x => x.GenreId == genreId);
    }
    
}