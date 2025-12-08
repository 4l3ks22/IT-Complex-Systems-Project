using EntityFramework.Interfaces;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.DataServices;

public class PersonData : IPersonData
{
    private readonly MyDbContext db;

    public PersonData(MyDbContext dbContext)
    {
        db = dbContext;
    }

    public int GetPersonsCount()
    {
        return db.Persons.Count();
    }

    /*public IList<Person> GetPersons(int page, int pageSize)
    { // Include all necessary navigation properties that are used in the DTO
        return db.Persons
            .Include(p => p.PersonProfessions)
            .ThenInclude(pp => pp.Profession)
            .Include(p => p.PersonRating)
            .Include(p => p.ParticipatesInTitles)
            .ThenInclude(pt => pt.TconstNavigation)
            .Include(p => p.ParticipatesInTitles)
            .ThenInclude(p => p.PersonProfession)
            .Include(kt => kt.KnownForTitles)
            .ThenInclude(kt => kt.TconstNavigation)
            .ToList();
    }*/
    
    //replacing above method to fix loading problem of GetPersons. It was missing pagination.
    //The request so overloaded to show a bunch of persons without pagination to show only 13 per page
    public IList<Person> GetPersons(QueryParams queryParams)
    { // Include all necessary navigation properties that are used in the DTO
        return db.Persons
            .Include(p => p.PersonProfessions)
            .ThenInclude(pp => pp.Profession)
            .Include(p => p.PersonRating)
            .Include(p => p.ParticipatesInTitles)
            .ThenInclude(pt => pt.TconstNavigation)
            .Include(p => p.ParticipatesInTitles)
            .ThenInclude(p => p.PersonProfession)
            .Include(kt => kt.KnownForTitles)
            .ThenInclude(kt => kt.TconstNavigation)
            .OrderBy(x => x.Nconst)
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .ToList();
    }
    public Person? GetById(string id)
    {
        return db.Persons
            .Include(p => p.PersonProfessions)
            .ThenInclude(pp => pp.Profession)
            .Include(p => p.PersonRating)
            .Include(p => p.ParticipatesInTitles)
            .ThenInclude(pt => pt.TconstNavigation)
            .Include(p => p.ParticipatesInTitles)
            .ThenInclude(p => p.PersonProfession)
            .Include(kt => kt.KnownForTitles)
            .ThenInclude(kt => kt.TconstNavigation)
            .FirstOrDefault(p => p.Nconst == id);
    }
    
    //Updated add version of SearchPersonsByName (actors)
    //it is more advisable to use built-in Contains method to obtain real search functionality, not just exact matching
    public IEnumerable<Person> SearchPersonsByName(string name)
    {
        return db.Persons
            .Include(p => p.PersonProfessions)
            .ThenInclude(pp => pp.Profession)
            .Include(p => p.PersonRating)
            .Include(p => p.ParticipatesInTitles)
            .ThenInclude(pt => pt.TconstNavigation)
            .Include(p => p.KnownForTitles)
            .ThenInclude(kt => kt.TconstNavigation)
            .Where(p => p.Primaryname.ToLower().Contains(name.ToLower()))
            .ToList();
    }
}