using EntityFramework.Interfaces;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.DataServices;

public class TitleData(MyDbContext db) : ITitleData // this is like having var db = new MyDbContext
{
    public int GetTitlesCount()
    {
        return db.Titles.Count(); // Titles is from MyDbContext
    }

    public IList<Title> GetTitles(QueryParams queryParams)
    {

        return db.Titles
        .OrderBy(x => x.Tconst)
        .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
        .Take(queryParams.PageSize)
        .ToList();
    }

    public Title? GetTitleById(string tconst)
    {
        return db.Titles
            .FirstOrDefault(x => x.Tconst == tconst);
    }

    public IList<Title> GetTitleByName(string primarytitle)
    {
        return db.Titles.Where(x => x.Primarytitle.ToLower().Contains(primarytitle.ToLower())).ToList();
    }
}