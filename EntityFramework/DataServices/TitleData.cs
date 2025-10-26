using EntityFramework.Interfaces;
using EntityFramework.Models;

namespace EntityFramework.DataServices;

public class TitleData(MyDbContext db) : ITitleData
{
    public List<Title> GetTitles()
    {
    return db.Titles.Where(t => !string.IsNullOrEmpty(t.Tconst)).ToList();
    }

    public Title GetById(string id)
    {
        return db.Titles
            .Where(t => !string.IsNullOrEmpty(t.Tconst))
            .SingleOrDefault(t => t.Tconst == id);
    }
}