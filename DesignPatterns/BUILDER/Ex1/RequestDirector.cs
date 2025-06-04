namespace DesignPatterns.BUILDER.Ex1;

public class RequestDirector
{
    private readonly IHttpRequestBuilder _builder;
        
    public RequestDirector(IHttpRequestBuilder builder)
    {
        _builder = builder;
    }
        
    public HttpRequest BuildApiDataRequest(string resource, string format)
    {
        return _builder
            .Reset()
            .SetMethod("GET")
            .SetUrl($"https://api.example.com/{resource}")
            .AddHeader("Accept", $"application/{format}")
            .AddHeader("Authorization", "Bearer token123")
            .AddQueryParameter("format", format)
            .Build();
    }
        
    public HttpRequest BuildAuthRequest(string username, string password)
    {
        string body = $"{{\"username\":\"{username}\",\"password\":\"{password}\"}}";
            
        return _builder
            .Reset()
            .SetMethod("POST")
            .SetUrl("https://api.example.com/auth")
            .AddHeader("Content-Type", "application/json")
            .SetBody(body)
            .Build();
    }
}