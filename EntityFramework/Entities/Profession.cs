using System;
using System.Collections.Generic;

namespace EntityFramework.Entities;

public partial class Profession
{
    public int ProfessionId { get; set; }

    public string Profession1 { get; set; } = null!;

    public virtual ICollection<PersonProfession> PersonProfessions { get; set; } = new List<PersonProfession>();
}
