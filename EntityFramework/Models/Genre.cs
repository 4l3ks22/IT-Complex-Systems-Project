using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public class Genre
{
    public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;

    public virtual ICollection<Title> Tconsts { get; set; } = new List<Title>();
}
