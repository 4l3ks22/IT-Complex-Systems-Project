using EntityFramework.Models;

namespace EntityFramework.Interfaces;

public interface IGenreData
{

     int GetGenresCount();
     IList<Genre> GetGenres(QueryParams queryParams);
     Genre? GetGenreById(int genreId); 

}

