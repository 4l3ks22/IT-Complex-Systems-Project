using EntityFramework.Models;
using EntityFramework.Models.Interfaces;

namespace EntityFramework.DataServices;

public class GenreData : IGenreData
{
    private readonly MyDbContext _db;

    public GenreData(MyDbContext db) => _db = db;

    public List<string> GetGenres()
    {
        return _db.Genres
            .Select(g => g.GenreName)
            .Where(n => !string.IsNullOrEmpty(n))
            .ToList();
    }
}