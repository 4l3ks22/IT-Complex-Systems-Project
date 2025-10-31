using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public class Episode
{
    public string Tconst { get; set; } = null!;

    public string? Parenttconst { get; set; }

    public int? Seasonnumber { get; set; }

    public int? Episodenumber { get; set; }
    
    public virtual Title ParenttconstNavigation { get; set; }
    //public virtual ICollection<Title> ParenttconstNavigation { get; set; } = new List<Title>();
    //public Title ParenttconstNavigation { get; set; } // trying by cesar
    
}
