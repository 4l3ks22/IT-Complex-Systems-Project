using EntityFramework.Models;
using EntityFramework.Models.Interfaces;

namespace EntityFramework.DataServices;

public class GenreData(MyDbContext db) : IGenreData // Default constructor
{
    public List<string> GetGenres()
    {
        return db.Genres
            .Select(g => g.GenreName)
            .Where(n => !string.IsNullOrEmpty(n))
            .ToList();
    }
}