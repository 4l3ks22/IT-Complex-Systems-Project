using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class ParticipatesInTitle
{
    public string? Tconst { get; set; }

    public int? Ordering { get; set; }

    public string? Nconst { get; set; }

    public string? Category { get; set; }

    public string? Job { get; set; }

    public string? Characters { get; set; }

    public int ParticipationId { get; set; }

    public int? ProfessionId { get; set; }

    public virtual Person? NconstNavigation { get; set; }

    public virtual PersonProfession? PersonProfession { get; set; }

    public virtual Title? TconstNavigation { get; set; }
}
