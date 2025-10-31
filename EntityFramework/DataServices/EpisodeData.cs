/*using EntityFramework.Interfaces;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.DataServices;

public class EpisodeData(MyDbContext db) : IEpisodeData
{
   public List<Episode> GetEpisodes()
   {
       var episodes = db.Episodes.Include(e => e.ParenttconstNavigation).Where(e => !string.IsNullOrEmpty(e.Tconst))
           .ToList();
       return episodes;
   }

   public Episode GetById(string tconst)
   {
       return db.Episodes
           .Where(e => !string.IsNullOrEmpty(e.Tconst))
           .Include(t => t.Parenttconst)
           .FirstOrDefault(e => e.Tconst == tconst.ToString())!;
   }
}*/
using EntityFramework.Interfaces;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.DataServices;

public class EpisodeData(MyDbContext db) : IEpisodeData // this is like having var db = new MyDbContext
{
    //This approach was working but a little wrong 31-10-2025 5:37pm, because seriename and titleurl = null
    
    /*public int GetEpisodesCount()
    {
        return db.Episodes.Count(); // Titles is from MyDbContext
    }

    public IList<Episode> GetEpisodes(int page, int pageSize)
    {

        return db.Episodes
            .Include(x => x.ParenttconstNavigation)// Added by cesar. Including the navigation in titles
            .ThenInclude(x => x.Episodes )// Added by cesar
            //.OrderBy(x => x.Tconst)
            .OrderBy(x => x.Parenttconst)
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public Episode GetEpisodesById(string tconst)
    {
        return db.Episodes
            .Include(x => x.ParenttconstNavigation)// Added by cesar. Including the navigation in titles
            //.FirstOrDefault(x => x.Tconst == tconst);
            .ThenInclude(x => x.Episodes )// Added by cesar
            .FirstOrDefault(x => x.Parenttconst == tconst);
    }*/
    
    // this is ok
    public int GetEpisodesCount()
    {
        return db.Episodes.Count();
    }

    public IList<Episode> GetEpisodes(int page, int pageSize)
    {
        return db.Episodes
            .Include(x => x.ParenttconstNavigation) // Include the parent Title (the series)
            .OrderBy(x => x.Parenttconst)
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public Episode GetEpisodesById(string tconst)
    {
        // Filtering by Tconst (the episode's own ID). Do not get confused to filter with Parenttconst
        return db.Episodes
            .Include(x => x.ParenttconstNavigation)
            .FirstOrDefault(x => x.Tconst == tconst);
    }
    
    
    
}
