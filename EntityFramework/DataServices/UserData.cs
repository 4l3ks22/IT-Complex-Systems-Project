using EntityFramework.Interfaces;
using EntityFramework.Models;

namespace EntityFramework.DataServices;

public class UserData(MyDbContext db) : IUserData
{

    public int GetUsersCount()
    {
        return db.Users.Count();
    }

    public List<User> GetUsers(int page, int pageSize)
    {
        return db.Users
            .OrderBy(x => x.UserId)
            .Skip(page * pageSize)
            .Take(pageSize)
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
        db.SaveChanges();
    }
}
