using EntityFramework.Interfaces;
using EntityFramework.Models;

namespace EntityFramework.DataServices;

public class BookmarkData(MyDbContext db): IBookmarkData
{
    public int GetBookmarksCountByUserId(int userId)
    {
        return db.UserBookmarks.Where(x => x.UserId == userId).Count();
    }

    public bool CheckBookmarkExists(UserBookmark bookmark)
    {
        return db.UserBookmarks.Any(x => x.UserId == bookmark.UserId &&(
            (x.Tconst == bookmark.Tconst) || (x.Nconst == bookmark.Nconst)
        ));
    }

    public int GetBookmarksCount()
    {
        return db.UserBookmarks.Count();
    }
    public List<UserBookmark> GetAllBookmarks(QueryParams queryParams)
    {
        return db.UserBookmarks
            .OrderBy(x=>x.BookmarkId)
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .ToList();
    }
    public List<UserBookmark> GetBookmarksByUserId(QueryParams queryParams,int userId)
    {
        return db.UserBookmarks
            .Where(x => x.UserId == userId).OrderBy(x=>x.BookmarkId)
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .ToList();
    }

    public UserBookmark GetBookmarkById(int bookmarkId)
    {
        return db.UserBookmarks.FirstOrDefault(x => x.BookmarkId == bookmarkId);
    }

    public void AddUserBookmark(UserBookmark userBookmark)
    {
        db.UserBookmarks.Add(userBookmark);
        db.SaveChanges();
    }

    public void DeleteUserBookmark(UserBookmark userBookmark)
    {
        db.UserBookmarks.Remove(userBookmark);
        db.SaveChanges();
    }
}
