namespace DesignPatterns.BUILDER.Ex1;

public class HttpRequestBuilder: IHttpRequestBuilder
{
    private HttpRequest _request = new HttpRequest();
        
    public virtual IHttpRequestBuilder SetMethod(string method)
    {
        _request.Method = method;
        return this;
    }
        
    public IHttpRequestBuilder SetUrl(string url)
    {
        _request.Url = url;
        return this;
    }
        
    public IHttpRequestBuilder AddHeader(string name, string value)
    {
        _request.Headers[name] = value;
        return this;
    }
        
    public IHttpRequestBuilder AddQueryParameter(string name, string value)
    {
        _request.QueryParameters[name] = value;
        return this;
    }
        
    public IHttpRequestBuilder SetBody(string body)
    {
        _request.Body = body;
        return this;
    }
        
    public HttpRequest Build()
    {
        return _request;
    }
        
    public IHttpRequestBuilder Reset()
    {
        _request = new HttpRequest();
        return this;
    }
}