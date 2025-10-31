using EntityFramework.Models;

namespace EntityFramework.Interfaces;

public interface IEpisodeData
{
    
    public int GetEpisodesCount();
    public IList<Episode> GetEpisodes(int page, int pageSize);
    public Episode GetEpisodesById(string id);
}

