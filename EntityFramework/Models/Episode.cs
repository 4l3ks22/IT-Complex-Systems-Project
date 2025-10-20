using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class Episode
{
    public string Tconst { get; set; } = null!;

    public string? Parenttconst { get; set; }

    public int? Seasonnumber { get; set; }

    public int? Episodenumber { get; set; }

    public virtual Title? ParenttconstNavigation { get; set; }
}
