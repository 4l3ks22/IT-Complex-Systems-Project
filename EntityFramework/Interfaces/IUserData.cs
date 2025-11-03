using EntityFramework.Models;

namespace EntityFramework.Interfaces;

public interface IUserData
{
    int GetUsersCount();
    public List<User> GetUsers(int page, int pageSize);
    public User GetUserByUsername(string username);
    public User GetUserById(int userId);
    void AddUser(User user);

}