using EntityFramework.Interfaces;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using EntityFramework.DataServices;

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
        user.PasswordHash = PasswordHasher.Hash(user.PasswordHash);
        db.Users.Add(user);
        db.SaveChanges(); }

    public void UpdateUser(User user)
    {
        user.PasswordHash = PasswordHasher.Hash(user.PasswordHash);
        db.Users.Update(user);
        db.SaveChanges();
    }
    
    public void DeleteUser(User user)
    {
        db.Users.Remove(user);
        db.SaveChanges();
    }

        public User LoginUser(string username, string password)
        {
            User? user = GetUserByUsername(username);
            if (user is null)
            {
                throw new Exception(@"User not found");
            }

            bool verified = PasswordHasher.Verify(password, user.PasswordHash);
            if (!verified)
            {
                throw new Exception("Password is incorrect");
            }

            return user;
        }
}
