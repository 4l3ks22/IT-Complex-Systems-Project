using EntityFramework.Models;
using Version = EntityFramework.Models.Version;

namespace EntityFramework.Interfaces;

public interface IVersionData
{
    public int GetVersionsCount();
    public IList<Version> GetVersions(QueryParams queryParams);
}