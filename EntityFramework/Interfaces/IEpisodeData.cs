namespace EntityFramework.Models.Interfaces;

public interface IEpisodeData
{
    List<Episode> GetEpisodes();
    Episode GetById(int id);
}

