using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string Genre1 { get; set; } = null!;

    public virtual ICollection<Title> Tconsts { get; set; } = new List<Title>();
}
