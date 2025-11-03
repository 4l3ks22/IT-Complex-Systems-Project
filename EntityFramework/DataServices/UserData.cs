using EntityFramework.Interfaces;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.DataServices;

public class UserData(MyDbContext db) : IUserData
{

    public int GetUsersCount()
    {
        return db.Users.Count();
    }

    public List<User> GetUsers(QueryParams queryParams)
    {
        return db.Users
        .OrderBy(x => x.UserId)
        .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
        .Take(queryParams.PageSize)
        .ToList();
    }

    public User GetUserByUsername(string username)
    {
        return db.Users.FirstOrDefault(x => x.Username == username);
    }

    public User GetUserById(int userId)
    {
        return db.Users.FirstOrDefault(x => x.UserId == userId);
    }

    public void AddUser(User user)
    {
        db.Users.Add(user);
        db.SaveChanges(); }
}
