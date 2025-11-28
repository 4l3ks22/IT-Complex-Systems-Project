using EntityFramework.Interfaces;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.DataServices;

public class TitleData(MyDbContext db) : ITitleData 
{
    public int GetTitlesCount()
    {
        return db.Titles.Count(); 
    }

    public IList<Title> GetTitles(QueryParams queryParams)
    {

        return db.Titles
            .Include(t => t.TitleExtra) // TitleExtra is navigation path in Title model, defined there as attribute 
            .Include(t => t.Rating)// Rating is navigation path in Title model, defined there as attribute 
            .Include(t => t.Versions)// Versions is navigation path in Title model, defined there as attribute 
            .Include(g => g.TitleGenres)
            .ThenInclude(g => g.Genre)
            .OrderBy(x => x.Tconst)
        .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
        .Take(queryParams.PageSize)
        .ToList();
    }

    public Title? GetTitleById(string tconst)
    {
        return db.Titles
            .Include(t => t.TitleExtra) 
            .Include(t => t.Rating)
            .Include(t => t.Versions)
            .Include(g => g.TitleGenres)
            .ThenInclude(g => g.Genre)
            .FirstOrDefault(x => x.Tconst == tconst);
    }

    /*public IList<Title> GetTitleByName(string primarytitle)
    {
        return db.Titles.Where(x => x.Primarytitle.ToLower().Contains(primarytitle.ToLower())).ToList();
    }*/
    
    //Updated version of GetTitleByName to be active
    public IList<Title> SearchTitlesByName(string name)
    {
        /*if (string.IsNullOrWhiteSpace(name))
            return new List<Title>();*/

        return db.Titles
            .Include(t => t.TitleExtra)
            .Include(t => t.Rating)
            .Include(t => t.Versions)
            .Include(g => g.TitleGenres).ThenInclude(g => g.Genre)
            .Where(t => t.Primarytitle.ToLower().Contains(name.ToLower()))
            .OrderBy(t => t.Primarytitle)
            .Take(20)        // let's limit results to 20 titles for that number, otherwise too heavy less efficient
            .ToList();
    }
}