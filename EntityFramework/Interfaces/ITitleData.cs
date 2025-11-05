using EntityFramework.Models;

namespace EntityFramework.Interfaces;

public interface ITitleData
{

    int GetTitlesCount();
    IList<Title> GetTitles(QueryParams queryParams);
    Title? GetTitleById(string tconst); 
    
}