using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class Person
{
    public string Nconst { get; set; } = null!;

    public string? Primaryname { get; set; }

    public string? Birthyear { get; set; }

    public string? Deathyear { get; set; }

    public virtual ICollection<ParticipatesInTitle> ParticipatesInTitles { get; set; } = new List<ParticipatesInTitle>();

    public virtual ICollection<PersonProfession> PersonProfessions { get; set; } = new List<PersonProfession>();

    public virtual PersonRating? PersonRating { get; set; }

    public virtual ICollection<UserBookmark> UserBookmarks { get; set; } = new List<UserBookmark>();

    public virtual ICollection<Title> Tconsts { get; set; } = new List<Title>();
}
