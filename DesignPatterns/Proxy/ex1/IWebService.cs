namespace DesignPatterns.Proxy.ex1;

public interface IWebService
{
    string GetPublicData(string resource);
    string GetProtectedData(string resource);
    void ModifyData(string resource, string data);
}