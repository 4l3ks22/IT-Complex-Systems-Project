using EntityFramework.Models;

namespace EntityFramework.Interfaces;

public interface IEpisodeData
{
    List<Episode> GetEpisodes();
    Episode GetById(int id);
}

