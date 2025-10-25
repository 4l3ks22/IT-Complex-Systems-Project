namespace EntityFramework.Models.Interfaces;

public interface ITitleData
{
    public List<Title> GetTitles();
    
    Title GetById(string id);
    
}