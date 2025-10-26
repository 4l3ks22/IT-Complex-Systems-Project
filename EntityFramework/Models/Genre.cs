using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public class Genre
{
    public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;

    public ICollection<Title> Tconsts { get; set; } = new List<Title>();
    
    public ICollection<TitleGenre> TitleGenres { get; set; } = new List<TitleGenre>();
}
