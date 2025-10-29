using EntityFramework.Models;

namespace EntityFramework.Interfaces;

/*public interface ITitleData
{
    public List<Title> GetTitles();
    
    Title GetById(string id);
    
}*/

public interface ITitleData
{

    int GetTitlesCount();
    IList<Title> GetTitles(int page, int pageSize);
    Title? GetTitleById(string tconst); 
    
}