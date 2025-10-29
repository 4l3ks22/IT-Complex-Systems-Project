using EntityFramework.Models;

namespace EntityFramework.Interfaces;

public interface IPersonData
{
    public int GetPersonsCount();
    public IList<Person> GetPersons(int page, int pageSize);
    
    public Person GetById(string id);
}