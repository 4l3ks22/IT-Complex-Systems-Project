using System;
using System.Collections.Generic;

namespace EntityFramework.Entities;

public partial class PersonProfession
{
    public string Nconst { get; set; } = null!;

    public int ProfessionId { get; set; }

    public virtual Person NconstNavigation { get; set; } = null!;

    public virtual ICollection<ParticipatesInTitle> ParticipatesInTitles { get; set; } = new List<ParticipatesInTitle>();

    public virtual Profession Profession { get; set; } = null!;
}
