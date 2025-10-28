using EntityFramework.Interfaces;
using EntityFramework.Models;

namespace EntityFramework.DataServices;

/*public class TitleData(MyDbContext db) : ITitleData
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
}*/

public class TitleData(MyDbContext db) : ITitleData // this is like having var db = new MyDbContext
{
    public int GetTitlesCount()
    {
        return db.Titles.Count(); // Titles is from MyDbContext
    }

    public IList<Title> GetTitles(int page, int pageSize)
    {
        
        return db.Titles
            .OrderBy(x => x.Tconst)
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public Title? GetTitleById(string tconst)
    {
        return db.Titles.FirstOrDefault(x => x.Tconst == tconst);
    }

    public void CreateTitle(Title title)
    {
        var maxTconst = db.Titles.Max(x => x.Tconst);
        title.Tconst = maxTconst + 1;          // ojo I think this is wrong because tconst is a string
        db.Titles.Add(title);
        db.SaveChanges();
    }

    public bool UpdateTitle(Title title)
    {
        db.Update(title);
        return db.SaveChanges() > 0;
    }

    public bool DeleteTitle(string tconst)
    {
        var title = db.Titles.Find(tconst);
        if ((title == null))
        {
            return false;
        }

        db.Titles.Remove(title);
        return db.SaveChanges() > 0;
    }

    public IList<Title> GetTitleByName(string primarytitle)
    {
        return db.Titles.Where(x => x.Primarytitle.ToLower().Contains(primarytitle.ToLower())).ToList();
    }
}