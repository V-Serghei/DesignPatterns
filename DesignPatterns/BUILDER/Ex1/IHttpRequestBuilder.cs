namespace DesignPatterns.BUILDER.Ex1;

public interface IHttpRequestBuilder
{
    IHttpRequestBuilder SetMethod(string method);
    IHttpRequestBuilder SetUrl(string url);
    IHttpRequestBuilder AddHeader(string name, string value);
    IHttpRequestBuilder AddQueryParameter(string name, string value);
    IHttpRequestBuilder SetBody(string body);
    HttpRequest Build();
    IHttpRequestBuilder Reset();
}