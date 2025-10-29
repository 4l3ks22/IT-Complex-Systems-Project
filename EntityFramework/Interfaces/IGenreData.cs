using EntityFramework.Models;

namespace EntityFramework.Interfaces;

public interface IGenreData
{

     int GetGenresCount();
     IList<Genre> GetGenres(int page, int pageSize);
     Genre? GetGenreById(int genreId); 

}

