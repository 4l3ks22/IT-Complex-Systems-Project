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
    public int GetEpisodesCount()
    {
        return db.Episodes.Count(); // Titles is from MyDbContext
    }

    public IList<Episode> GetEpisodes(int page, int pageSize)
    {

        return db.Episodes
            .OrderBy(x => x.Tconst)
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public Episode GetEpisodesById(string tconst)
    {
        return db.Episodes
            .FirstOrDefault(x => x.Tconst == tconst);
    }

    
}
