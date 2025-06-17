namespace DesignPatterns.Proxy.ex1;

public class WebServiceProxy
    : IWebService
{
    private readonly RealWebService _realWebService;
    private readonly User _currentUser;

    public WebServiceProxy(User user)
    {
        _realWebService = new RealWebService();
        _currentUser = user;
    }

    // Public data is accessible to everyone
    public string GetPublicData(string resource)
    {
        Console.WriteLine($"Proxy: {_currentUser.Username} requests public data: {resource}");
        return _realWebService.GetPublicData(resource);
    }

    // Protected data requires at least "user" role
    public string GetProtectedData(string resource)
    {
        Console.WriteLine($"Proxy: {_currentUser.Username} requests protected data: {resource}");
            
        if (_currentUser.Role == "guest")
        {
            Console.WriteLine("Proxy: Access denied - insufficient permissions");
            return "Access denied";
        }
            
        return _realWebService.GetProtectedData(resource);
    }

    // Modify operations require "admin" role
    public void ModifyData(string resource, string data)
    {
        Console.WriteLine($"Proxy: {_currentUser.Username} attempts to modify {resource}");
            
        if (_currentUser.Role != "admin")
        {
            Console.WriteLine("Proxy: Access denied - admin permissions required");
            return;
        }
            
        _realWebService.ModifyData(resource, data);
    }
}