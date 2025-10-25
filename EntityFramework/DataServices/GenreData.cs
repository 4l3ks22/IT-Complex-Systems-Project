using EntityFramework.Models;
using EntityFramework.Models.Interfaces;

namespace EntityFramework.DataServices;

public class GenreData(MyDbContext db) : IGenreData // Default constructor
{
    public List<Genre> GetGenres()
    {
        return db.Genres
            .Where(g => !string.IsNullOrEmpty(g.GenreName))
            .ToList();
    }
}