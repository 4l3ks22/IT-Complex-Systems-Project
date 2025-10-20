using System;
using System.Collections.Generic;

namespace EntityFramework.Models;
public partial class UserBookmark
{
    public int BookmarkId { get; set; }

    public int? UserId { get; set; }

    public string? Tconst { get; set; }

    public string? Nconst { get; set; }

    public DateTime? BookmarkTime { get; set; }

    public virtual Person? NconstNavigation { get; set; }

    public virtual Title? TconstNavigation { get; set; }

    public virtual User? User { get; set; }
}
