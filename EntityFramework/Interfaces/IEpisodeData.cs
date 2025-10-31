using EntityFramework.Models;

namespace EntityFramework.Interfaces;

public interface IEpisodeData
{
    
    int GetEpisodesCount();
    IList<Episode> GetEpisodes(int page, int pageSize);
    Episode GetEpisodesById(string id);
}

