using System;
using System.Collections.Generic;

namespace EntityFramework.Models;
public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? CreationTime { get; set; }

    public virtual ICollection<UserBookmark> UserBookmarks { get; set; } = new List<UserBookmark>();

    public virtual ICollection<UserRatingHistory> UserRatingHistories { get; set; } = new List<UserRatingHistory>();

    public virtual ICollection<UserSearchHistory> UserSearchHistories { get; set; } = new List<UserSearchHistory>();
}
