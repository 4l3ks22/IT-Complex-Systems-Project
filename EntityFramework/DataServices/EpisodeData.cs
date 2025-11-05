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

    public IList<Episode> GetEpisodes(QueryParams queryParams)
    {
        return db.Episodes
            .Include(x => x.ParenttconstNavigation) // Include navigation to the parent title
            .OrderBy(x => x.Parenttconst)
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
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
