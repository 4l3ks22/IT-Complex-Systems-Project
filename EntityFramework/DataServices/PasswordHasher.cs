using System.Security.Cryptography;
using EntityFramework.Interfaces;

namespace EntityFramework.DataServices;

public sealed class PasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 100000;
    
    private static readonly HashAlgorithmName Algorith = HashAlgorithmName.SHA512;

    public static string Hash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorith, HashSize);
        return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
    }

    public static bool Verify(string password, string passwordHash)
    {
        string[] parts = passwordHash.Split("-");
        byte[] hash = Convert.FromHexString(parts[0]);
        byte[] salt = Convert.FromHexString(parts[1]);
        
        byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password,salt, Iterations, Algorith, HashSize);
        return CryptographicOperations.FixedTimeEquals(hash, inputHash);
    }
}   