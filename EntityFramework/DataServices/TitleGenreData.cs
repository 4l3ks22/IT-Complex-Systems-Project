using EntityFramework.Interfaces;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.DataServices;

public class TitleGenreData(MyDbContext db) : ITitleGenreData
{
    public List<TitleGenre> GetTitleGenres()
    {
        return db.TitleGenres
            .ToList();
    }

    public List<TitleGenre> GetTitleGenresByTitleId(string titleId)
    {
        return db.TitleGenres
            .Where(tg => tg.Tconst == titleId)
            .ToList();
    }
}