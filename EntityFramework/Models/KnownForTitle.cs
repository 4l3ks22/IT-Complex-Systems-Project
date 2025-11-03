using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityFramework.Models;

public class KnownForTitle
{
    public string? Nconst { get; set; }
    public string? Tconst { get; set; }
    
    public Person? NconstNavigation { get; set; }
    
    public Title? TconstNavigation { get; set; }
    
}