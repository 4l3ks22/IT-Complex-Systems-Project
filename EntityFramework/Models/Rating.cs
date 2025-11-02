using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public class Rating
{
    public string Tconst { get; set; } = null!;

    public decimal? Averagerating { get; set; }

    public int? Numvotes { get; set; }

    public virtual Title TconstNavigation { get; set; } = null!; //The navigation path of Title in Rating model
}
