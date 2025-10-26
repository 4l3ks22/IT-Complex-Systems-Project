using EntityFramework.Interfaces;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.DataServices;

public class EpisodeData(MyDbContext db) : IEpisodeData
{
   public List<Episode> GetEpisodes()
   {
      return db.Episodes
         .Where(e => !string.IsNullOrEmpty(e.Tconst))
         .ToList();
   }
   
   public Episode GetById(int id)
   {
       return db.Episodes
           .Where(e => !string.IsNullOrEmpty(e.Tconst))
           .Include(t => t.Parenttconst)
           .FirstOrDefault(e => e.Tconst == id.ToString())!;
   }
}