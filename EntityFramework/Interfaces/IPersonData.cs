using EntityFramework.Models;

namespace EntityFramework.Interfaces;

public interface IPersonData
{
    public int GetPersonsCount();
    //public IList<Person> GetPersons(int page, int pageSize);
    //replacing this interface to add pagination to the parameter
    public IList<Person> GetPersons(QueryParams queryParams);
    
    public Person GetById(string id);
    
    //Implementing new interface to search actors (persons) by name
    IEnumerable<Person> SearchPersonsByName(string name);
}