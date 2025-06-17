using DesignPatterns.Proxy.ex1;

namespace DesignPatterns.Client.Proxy;

public class ProxyClient
{
    public void Run()
    {
        Console.WriteLine("===== Guest User Access =====");
        var guestUser = new User("JohnDoe", "guest");
        IWebService guestProxy = new WebServiceProxy(guestUser);
            
        // Guest can access public data
        Console.WriteLine(guestProxy.GetPublicData("news"));
            
        // Guest cannot access protected data
        Console.WriteLine(guestProxy.GetProtectedData("reports"));
            
        // Guest cannot modify data
        guestProxy.ModifyData("users", "New data");
            
        Console.WriteLine("\n===== Regular User Access =====");
        var regularUser = new User("JaneSmith", "user");
        IWebService userProxy = new WebServiceProxy(regularUser);
            
        // Regular user can access public data
        Console.WriteLine(userProxy.GetPublicData("news"));
            
        // Regular user can access protected data
        Console.WriteLine(userProxy.GetProtectedData("reports"));
            
        // Regular user cannot modify data
        userProxy.ModifyData("users", "New data");
            
        Console.WriteLine("\n===== Admin User Access =====");
        var adminUser = new User("AdminUser", "admin");
        IWebService adminProxy = new WebServiceProxy(adminUser);
            
        // Admin can access everything and modify data
        Console.WriteLine(adminProxy.GetPublicData("news"));
        Console.WriteLine(adminProxy.GetProtectedData("users"));
        adminProxy.ModifyData("users", "Updated user information");
        Console.WriteLine(adminProxy.GetProtectedData("users"));
    }
}