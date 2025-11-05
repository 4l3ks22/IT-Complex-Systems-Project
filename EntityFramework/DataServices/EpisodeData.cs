using EntityFramework.Interfaces;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.DataServices;

public class EpisodeData(MyDbContext db) : IEpisodeData // this is like having var db = new MyDbContext
{
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
