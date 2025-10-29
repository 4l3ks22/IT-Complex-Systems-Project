using EntityFramework.Interfaces;
using EntityFramework.Models;


namespace EntityFramework.DataServices;

public class GenreData(MyDbContext db) : IGenreData 
{
    public List<Genre> GetGenres()
    {
        return db.Genres
            .Where(g => !string.IsNullOrEmpty(g.GenreName))
            .ToList();
    }

    public Genre GetById(int id)
    {
        return db.Genres.Find(id);
    }
    
}