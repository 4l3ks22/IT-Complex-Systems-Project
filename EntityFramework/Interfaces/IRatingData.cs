public interface IRatingData
{
    void Rate(int userId, string tconst, int rating);

    List<UserRatingHistory> GetUserRating(int userId);
    
}