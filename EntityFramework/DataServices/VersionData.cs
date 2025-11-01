using EntityFramework.Interfaces;
using EntityFramework.Models;
using Version = EntityFramework.Models.Version;

namespace EntityFramework.DataServices;

public class VersionData(MyDbContext db) : IVersionData
{
    public int GetVersionsCount()
    {
        return db.Versions.Count();
    }

    public IList<Version> GetVersions(QueryParams queryParams)
    {
        return db.Versions
            .OrderBy(x => x.Tconst)
            .ThenBy(x => x.Ordering)
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .ToList();
    }
}