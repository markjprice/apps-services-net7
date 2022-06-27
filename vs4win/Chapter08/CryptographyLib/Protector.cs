using System.Diagnostics; // Stopwatch
using System.Security.Cryptography; // Aes, Rfc2898DeriveBytes, etc.
using System.Security.Principal; // GenericIdentity, GenericPrincipal
using System.Text; // Encoding

using static System.Convert; // ToBase64String, FromBase64String

namespace Packt.Shared;

public static class Protector
{
  // salt size must be at least 8 bytes, we will use 16 bytes
  private static readonly byte[] salt =
    Encoding.Unicode.GetBytes("7BANANAS");

  // Default iterations for Rfc2898DeriveBytes is 1000.
  // Iterations should be high enough to take at least 100ms to 
  // generate a Key and IV on the target machine. 150,000 iterations
  // takes 139ms on my 11th Gen Intel Core i7-1165G7 @ 2.80GHz.
  private static readonly int iterations = 150_000;

  public static string Encrypt(
    string plainText, string password)
  {
    byte[] encryptedBytes;
    byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);

    using (Aes aes = Aes.Create()) // abstract class factory method
    {
      // record how long it takes to generate the Key and IV
      Stopwatch timer = Stopwatch.StartNew();

      using (Rfc2898DeriveBytes pbkdf2 = new(
        password, salt, iterations, HashAlgorithmName.SHA256))
      {
        WriteLine("PBKDF2 algorithm: {0}, Iteration count: {1:N0}",
          pbkdf2.HashAlgorithm, pbkdf2.IterationCount);

        aes.Key = pbkdf2.GetBytes(32); // set a 256-bit key
        aes.IV = pbkdf2.GetBytes(16); // set a 128-bit IV
      }

      timer.Stop();

      WriteLine("{0:N0} milliseconds to generate Key and IV.",
        arg0: timer.ElapsedMilliseconds);

      WriteLine("Encryption algorithm: {0}-{1}, {2} mode with {3} padding.",
        "AES", aes.KeySize, aes.Mode, aes.Padding);

      using (MemoryStream ms = new())
      {
        using (ICryptoTransform transformer = aes.CreateEncryptor())
        {
          using (CryptoStream cs = new(
            ms, transformer, CryptoStreamMode.Write))
          {
            cs.Write(plainBytes, 0, plainBytes.Length);

            if (!cs.HasFlushedFinalBlock)
            {
              cs.FlushFinalBlock();
            }
          }
        }
        encryptedBytes = ms.ToArray();
      }
    }

    return ToBase64String(encryptedBytes);
  }

  public static string Decrypt(
    string cipherText, string password)
  {
    byte[] plainBytes;
    byte[] cryptoBytes = FromBase64String(cipherText);

    using (Aes aes = Aes.Create())
    {
      using (Rfc2898DeriveBytes pbkdf2 = new(
        password, salt, iterations, HashAlgorithmName.SHA256))
      {
        aes.Key = pbkdf2.GetBytes(32);
        aes.IV = pbkdf2.GetBytes(16);
      }

      using (MemoryStream ms = new())
      {
        using (ICryptoTransform transformer = aes.CreateDecryptor())
        {
          using (CryptoStream cs = new(
            ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
          {
            cs.Write(cryptoBytes, 0, cryptoBytes.Length);

            if (!cs.HasFlushedFinalBlock)
            {
              cs.FlushFinalBlock();
            }
          }
        }
        plainBytes = ms.ToArray();
      }
    }

    return Encoding.Unicode.GetString(plainBytes);
  }

  private static Dictionary<string, User> Users = new();

  public static User Register(string username,
    string password, string[]? roles = null)
  {
    // generate a random salt
    RandomNumberGenerator rng = RandomNumberGenerator.Create();
    byte[] saltBytes = new byte[16];
    rng.GetBytes(saltBytes);
    string saltText = ToBase64String(saltBytes);

    // generate the salted and hashed password
    string saltedhashedPassword = SaltAndHashPassword(password, saltText);

    User user = new(username, saltText,
      saltedhashedPassword, roles);

    Users.Add(user.Name, user);

    return user;
  }

  public static void LogIn(string username, string password)
  {
    if (CheckPassword(username, password))
    {
      GenericIdentity gi = new(
        name: username, type: "PacktAuth");

      GenericPrincipal gp = new(
        identity: gi, roles: Users[username].Roles);

      // set the principal on the current thread so that
      // it will be used for authorization by default
      Thread.CurrentPrincipal = gp;
    }
  }

  // check a user's password that is stored
  // in the private static dictionary Users
  public static bool CheckPassword(string username, string password)
  {
    if (!Users.ContainsKey(username))
    {
      return false;
    }

    User u = Users[username];

    return CheckPassword(password,
      u.Salt, u.SaltedHashedPassword);
  }

  // check a password using salt and hashed password
  public static bool CheckPassword(string password,
    string salt, string hashedPassword)
  {
    // re-generate the salted and hashed password 
    string saltedhashedPassword = SaltAndHashPassword(
      password, salt);

    return (saltedhashedPassword == hashedPassword);
  }

  private static string SaltAndHashPassword(string password, string salt)
  {
    using (SHA256 sha = SHA256.Create())
    {
      string saltedPassword = password + salt;
      return ToBase64String(sha.ComputeHash(
        Encoding.Unicode.GetBytes(saltedPassword)));
    }
  }

  public static string? PublicKey;

  public static string GenerateSignature(string data)
  {
    byte[] dataBytes = Encoding.Unicode.GetBytes(data);
    SHA256 sha = SHA256.Create();
    byte[] hashedData = sha.ComputeHash(dataBytes);
    RSA rsa = RSA.Create();

    PublicKey = rsa.ToXmlString(false); // exclude private key

    return ToBase64String(rsa.SignHash(hashedData,
      HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
  }

  public static bool ValidateSignature(
    string data, string signature)
  {
    if (PublicKey is null) return false;

    byte[] dataBytes = Encoding.Unicode.GetBytes(data);
    SHA256 sha = SHA256.Create();

    byte[] hashedData = sha.ComputeHash(dataBytes);
    byte[] signatureBytes = FromBase64String(signature);

    RSA rsa = RSA.Create();
    rsa.FromXmlString(PublicKey);

    return rsa.VerifyHash(hashedData, signatureBytes,
      HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
  }

  public static byte[] GetRandomKeyOrIV(int size)
  {
    RandomNumberGenerator r = RandomNumberGenerator.Create();

    byte[] data = new byte[size];
    r.GetBytes(data);

    // data is an array now filled with
    // cryptographically strong random bytes
    return data;
  }

}