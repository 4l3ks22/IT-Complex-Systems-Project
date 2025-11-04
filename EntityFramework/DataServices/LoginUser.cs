using EntityFramework.Interfaces;
using EntityFramework.Models;

namespace EntityFramework.DataServices;

public class LoginUser(IUserData userData, IPasswordHasher passwordHasher)
{
    public record Request(string Username, string Password);

    public User Handle(Request request)
    {
        User? user = userData.GetUserByUsername(request.Username);
        if (user is null)
        {
            throw new Exception(@"User not found");
        }

        bool verified = passwordHasher.Verify(request.Password, user.PasswordHash);
        if (!verified)
        {
            throw new Exception("Password is incorrect");
        }

        return user;
    }
}