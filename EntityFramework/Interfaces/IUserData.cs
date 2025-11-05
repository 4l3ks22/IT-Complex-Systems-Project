using EntityFramework.Models;

namespace EntityFramework.Interfaces;

public interface IUserData
{
    int GetUsersCount();
    public List<User> GetUsers(QueryParams queryParams);
    public User GetUserById(int userId);
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(User user);

    public User GetUserByEmail(string email);
    User LoginUser(string username, string password);
}