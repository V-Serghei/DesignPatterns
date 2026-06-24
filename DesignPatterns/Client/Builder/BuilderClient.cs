using DesignPatterns.BUILDER.Ex1;

namespace DesignPatterns.Client.Builder;

public class BuilderClient
{
    public void Run()
    {
        Console.WriteLine("=== Direct builder usage ===");
        var getRequest = new HttpRequestBuilder()
            .SetMethod("GET")
            .SetUrl("https://api.example.com/users")
            .AddHeader("Accept", "application/json")
            .AddQueryParameter("page", "1")
            .Build();
        Console.WriteLine(getRequest);

        Console.WriteLine("\n=== Using RequestDirector ===");
        var director = new RequestDirector(new HttpRequestBuilder());

        Console.WriteLine("API request:");
        Console.WriteLine(director.BuildApiDataRequest("products", "json"));

        Console.WriteLine("\nAuth request:");
        Console.WriteLine(director.BuildAuthRequest("admin@example.com", "secret123"));
    }
}
