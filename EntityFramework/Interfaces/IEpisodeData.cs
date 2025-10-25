namespace EntityFramework.Models.Interfaces;

public interface IEpisodeData
{
    public List<Episode> GetEpisodes();
    public Episode GetById(int id);
}

