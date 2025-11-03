using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public class Title
{
    public string Tconst { get; set; } = null!;

    public string? Titletype { get; set; }

    public string? Primarytitle { get; set; }

    public string? Originaltitle { get; set; }

    public bool Isadult { get; set; }

    public string? Startyear { get; set; }

    public string? Endyear { get; set; }

    public int? Runtimeminutes { get; set; }

    public string? Genres { get; set; }
    
    

    public virtual ICollection<Episode> Episodes { get; set; } = new List<Episode>();

    public virtual ICollection<ParticipatesInTitle> ParticipatesInTitles { get; set; } = new List<ParticipatesInTitle>();
    
    public virtual ICollection<KnownForTitle> KnownForTitles { get; set; } = new List<KnownForTitle>();
    
    public virtual ICollection<UserBookmark> UserBookmarks { get; set; } = new List<UserBookmark>();

    public virtual ICollection<UserRatingHistory> UserRatingHistories { get; set; } = new List<UserRatingHistory>();

    public virtual ICollection<Version> Versions { get; set; } = new List<Version>();

    public virtual ICollection<WordIndex> WordIndices { get; set; } = new List<WordIndex>();

    public virtual ICollection<Genre> GenresNavigation { get; set; } = new List<Genre>();

    public virtual ICollection<Person> Nconsts { get; set; } = new List<Person>();
    
    public ICollection<TitleGenre> TitleGenres { get; set; } = new List<TitleGenre>();
    
    public virtual TitleExtra? TitleExtra { get; set; } = new (); //The navigation path of TitleExtra in Title model
    public virtual Rating? Rating { get; set; } = new (); //The navigation path of Rating in Title model
    //public virtual Version? Versions { get; set; } = new (); //The navigation path of Rating in Title model
}
