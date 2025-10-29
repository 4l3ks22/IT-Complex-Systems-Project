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

    public IList<Person> GetPersons(int page, int pageSize)
    {
        return db.Persons
            .Include(p => p.ParticipatesInTitles)
            .ThenInclude(pt => pt.TconstNavigation)
            .Include(p => p.PersonProfessions)
            .ThenInclude(pp => pp.Profession) 
            .Include(p => p.PersonRating)
            .OrderBy(x => x.Nconst)
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public Person? GetById(string id)
    {
        return db.Persons
            .Include(p => p.ParticipatesInTitles)
            .ThenInclude(pt => pt.TconstNavigation)
            .Include(p => p.PersonProfessions)
            .Include(p => p.PersonRating)
            .FirstOrDefault(p => p.Nconst == id);
    }
}