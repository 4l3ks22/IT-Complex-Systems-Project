using EntityFramework.Models;

namespace EntityFramework.Interfaces;

public interface IUserData
{
    int GetUsersCount();
    public List<User> GetUsers(QueryParams queryParams);
    public User GetUserByUsername(string username);
    public User GetUserById(int userId);
    void AddUser(User user);

}