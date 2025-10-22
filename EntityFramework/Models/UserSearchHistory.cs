using System;
using System.Collections.Generic;

namespace EntityFramework.Models;
public class UserSearchHistory
{
    public int UserId { get; set; }

    public string SearchTerm { get; set; } = null!;

    public DateTime SearchTime { get; set; }

    public virtual User User { get; set; } = null!;
}
