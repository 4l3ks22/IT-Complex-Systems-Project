using System;
using System.Collections.Generic;

namespace EntityFramework.Models;
public partial class TitleExtra
{
    public string? Tconst { get; set; }

    public string? Awards { get; set; }

    public string? Poster { get; set; }

    public string? Plot { get; set; }

    public virtual Title? TconstNavigation { get; set; }
}
