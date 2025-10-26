using EntityFramework.Models;

namespace EntityFramework.Interfaces;

public interface IGenreData
{
    List<Genre> GetGenres();
    
    Genre GetById(int id);
}

