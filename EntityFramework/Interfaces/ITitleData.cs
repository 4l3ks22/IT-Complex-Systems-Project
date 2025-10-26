using EntityFramework.Models;

namespace EntityFramework.Interfaces;

public interface ITitleData
{
    public List<Title> GetTitles();
    
    Title GetById(string id);
    
}