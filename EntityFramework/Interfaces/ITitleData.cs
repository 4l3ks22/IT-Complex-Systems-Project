using EntityFramework.Models;

namespace EntityFramework.Interfaces;

public interface ITitleData
{

    int GetTitlesCount();
    IList<Title> GetTitles(QueryParams queryParams);
    Title? GetTitleById(string tconst); 
    
    //Implementing new interface to search titles by name
    IList<Title> SearchTitlesByName(string name);
    
}