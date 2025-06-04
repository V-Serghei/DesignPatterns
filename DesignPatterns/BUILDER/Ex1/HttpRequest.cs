using System.Text;

namespace DesignPatterns.BUILDER.Ex1;

public class HttpRequest
{
    public string Method { get; set; }
    public string Url { get; set; }
    public Dictionary<string, string> Headers { get; } = new Dictionary<string, string>();
    public Dictionary<string, string> QueryParameters { get; } = new Dictionary<string, string>();
    public string Body { get; set; }
        
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{Method} {Url}");
            
        if (QueryParameters.Count > 0)
        {
            sb.Append("Query Parameters:");
            foreach (var param in QueryParameters)
                sb.AppendLine($"\n  {param.Key}: {param.Value}");
        }
            
        if (Headers.Count > 0)
        {
            sb.Append("Headers:");
            foreach (var header in Headers)
                sb.AppendLine($"\n  {header.Key}: {header.Value}");
        }
            
        if (!string.IsNullOrEmpty(Body))
        {
            sb.AppendLine("Body:");
            sb.AppendLine($"  {Body}");
        }
            
        return sb.ToString();
    }
}