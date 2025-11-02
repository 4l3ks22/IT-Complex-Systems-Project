using EntityFramework.Interfaces;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Version = EntityFramework.Models.Version;

namespace EntityFramework.DataServices;

public class VersionData(MyDbContext db) : IVersionData
{
    public int GetVersionsCount(string titleId)
    {
        return db.Versions.Count(x => x.Tconst == titleId);
    }

    public IList<Version> GetVersions(QueryParams queryParams, string titleId)
    {
        return db.Versions
            .Where(x => x.Tconst == titleId)
            .OrderBy(x => x.Tconst)
            .ThenBy(x => x.Ordering)
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .ToList();
    }

    public Version GetVersionByTitleId(string id)
    {

        return db.Versions
            .Include(x =>  x.TconstNavigation)
            .FirstOrDefault(x => x.Tconst == id);
        
    }

}