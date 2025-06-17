namespace DesignPatterns.Proxy.ex1;

public class RealWebService: IWebService
{
    private Dictionary<string, string> _dataStore = new Dictionary<string, string>
    {
        { "public/news", "Latest company news..." },
        { "protected/reports", "Financial reports for Q3..." },
        { "protected/users", "User database contents..." }
    };

    public string GetPublicData(string resource)
    {
        Console.WriteLine($"RealWebService: Fetching public data: {resource}");
        return _dataStore.ContainsKey($"public/{resource}") 
            ? _dataStore[$"public/{resource}"] 
            : "Resource not found";
    }

    public string GetProtectedData(string resource)
    {
        Console.WriteLine($"RealWebService: Fetching protected data: {resource}");
        return _dataStore.ContainsKey($"protected/{resource}") 
            ? _dataStore[$"protected/{resource}"] 
            : "Resource not found";
    }

    public void ModifyData(string resource, string data)
    {
        Console.WriteLine($"RealWebService: Modifying {resource} with data: {data}");
        _dataStore[$"protected/{resource}"] = data;
    }
}
