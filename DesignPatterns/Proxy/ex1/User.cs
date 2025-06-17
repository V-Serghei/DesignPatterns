namespace DesignPatterns.Proxy.ex1;

public class User
{
    public string Username { get; }
    public string Role { get; } // "guest", "user", "admin"

    public User(string username, string role)
    {
        Username = username;
        Role = role;
    }
}