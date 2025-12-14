using EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql;
namespace EntityFramework.DataServices;

public class RatingData : IRatingData
{
    private readonly MyDbContext db;

    public RatingData(MyDbContext dbContext)
    {
        db = dbContext;
    }

    public void Rate(int userId, string tconst, int rating)
    {
        db.Database.ExecuteSqlRaw(
            "SELECT rate(@userId, @tconst, @rating)",
            new NpgsqlParameter("@userId", userId),
            new NpgsqlParameter("@tconst", tconst),
            new NpgsqlParameter("@rating", rating)
        );
    }

    public List<UserRatingHistory> GetUserRating(int userId)
    {
        return db.UserRatingHistories
            .Include(r => r.TconstNavigation)
            .Where(r => r.UserId == userId)
            .ToList();
    }
}