using EntityFramework.Models;

namespace EntityFramework.Interfaces;

public interface IBookmarkData
{
    int  GetBookmarksCount();
    int GetBookmarksCountByUserId(int userId);
    public UserBookmark GetBookmarkById(int bookmarkId);
    public List<UserBookmark> GetAllBookmarks(QueryParams queryParams);
    public List<UserBookmark> GetBookmarksByUserId(QueryParams queryParams, int userId);
    void AddUserBookmark(UserBookmark userBookmark);
    void DeleteUserBookmark(UserBookmark userBookmark);
}