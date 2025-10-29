using EntityFramework.Interfaces;
using EntityFramework.Models;


namespace EntityFramework.DataServices;

public class GenreData(MyDbContext db) : IGenreData 
{
    /*public IList<Genre> GetGenres()
    {
        return db.Genres
            .Where(g => !string.IsNullOrEmpty(g.GenreName))
            .ToList();
    }

    public Genre GetById(int id)
    {
        return db.Genres.Find(id);
    }*/
    
    
    public int GetGenresCount()
    {
        return db.Genres.Count(); // Genres is from MyDbContext
    }
    
    public IList<Genre> GetGenres(int page, int pageSize)
    {
        
        return db.Genres
            .OrderBy(x => x.GenreId)
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();
    }
    
    public Genre? GetGenreById(int genreId)
    {
        return db.Genres.FirstOrDefault(x => x.GenreId == genreId);
    }
    
}