using System;
using System.Collections.Generic;

namespace EntityFramework.Models;
public partial class UserRatingHistory
{
    public int RatingId { get; set; }

    public int? UserId { get; set; }

    public string? Tconst { get; set; }

    public int? Rating { get; set; }

    public DateTime? RatingTime { get; set; }

    public virtual Title? TconstNavigation { get; set; }

    public virtual User? User { get; set; }
}
