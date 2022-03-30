namespace Packt.Shared;

public record class User(string Name, string Salt,
  string SaltedHashedPassword, string[]? Roles);
