using EntityFramework.Models;
using Version = EntityFramework.Models.Version;

namespace EntityFramework.Interfaces;

public interface IVersionData
{
    public int GetVersionsCount(string titleId);
    public IList<Version> GetVersions(QueryParams queryParams, string titleId);
    
    public Version GetVersionByTitleId(string id);
}