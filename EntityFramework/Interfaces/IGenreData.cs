namespace EntityFramework.Models.Interfaces;

public interface IGenreData
{
    List<Genre> GetGenres();
    
    Genre GetById(int id);
}

