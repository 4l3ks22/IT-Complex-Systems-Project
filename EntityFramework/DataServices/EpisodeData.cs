using EntityFramework.Interfaces;
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
}