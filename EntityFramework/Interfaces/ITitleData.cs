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
    void CreateTitle(Title title); // in case we need
    bool UpdateTitle(Title title); // in case we need
    bool DeleteTitle(string tconst); // in case we need
    
}