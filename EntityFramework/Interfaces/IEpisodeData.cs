using EntityFramework.Models;

namespace EntityFramework.Interfaces;

public interface IEpisodeData
{
    
    public int GetEpisodesCount();
    public IList<Episode> GetEpisodes(QueryParams queryParams);
    public Episode GetEpisodesById(string id);
}

