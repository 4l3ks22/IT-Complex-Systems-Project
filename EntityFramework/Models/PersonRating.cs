using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class PersonRating
{
    public string Nconst { get; set; } = null!;

    public decimal WeightedRating { get; set; }

    public virtual Person NconstNavigation { get; set; } = null!;
}
