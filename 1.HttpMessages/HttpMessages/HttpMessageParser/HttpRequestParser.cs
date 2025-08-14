using HttpMessageParser.Models;

namespace HttpMessageParser;


public class HttpRequestParser : IRequestParser
{
    public HttpRequest ParseRequest(string requestText)
    {
        // Request null
        if (requestText == null)
            throw new ArgumentNullException(nameof(requestText), "invalid request text");
        // empty request
        if (requestText == "") 
            throw new ArgumentException("Request text cannot be empty", nameof(requestText));
        
        var simple = requestText.Replace("\r\n", "\n").Replace('\r', '\n'); // Eliminar Carriage Return New line
        var lines = simple.Split('\n'); // Segmentar request

        // 
        if (lines.Length == 0 || string.IsNullOrWhiteSpace(lines[0]))
            throw new ArgumentException("Staring request text cannot be empty", nameof(requestText));

        // Segmentar request y indexar
        var start = lines[0].TrimEnd();
        int firstSpace = start.IndexOf(' ');
        int lastSpace = start.LastIndexOf(' ');

        // index incorrecto para start line
        if (firstSpace <= 0 || lastSpace <= firstSpace || lastSpace == start.Length - 1)
            throw new ArgumentException("Invalid request start line.", nameof(requestText));

        // METHOD / HTTP / Version
        string method = start.Substring(0, firstSpace);
        string target = start.Substring(firstSpace + 1, lastSpace - firstSpace - 1);  
        string version = start.Substring(lastSpace + 1);

        // Validaciones 
        if (string.IsNullOrWhiteSpace(method))
            throw new ArgumentException("HTTP METHOD missing", nameof(requestText));
        if (string.IsNullOrWhiteSpace(target) || !target.Contains("/"))
            throw new ArgumentException("Invalid request target.", nameof(requestText));
        if (string.IsNullOrWhiteSpace(version) || !version.StartsWith("HTTP", StringComparison.OrdinalIgnoreCase))
            throw new ArgumentException("Version must start with HTTP.", nameof(requestText));

        // Headers
        var headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        bool BlankLine = false;
        int i = 1;

        for (; i < lines.Length; i++)
        {
            var line = lines[i]; 
            // Espacio en blanco termina Header
            if (line.Length == 0)
            {       
                BlankLine = true;
                i++;
                break;
            }

            // Verificar que solo exista 1 :
            int colonCount = line.Count(c => c == ':');
            if (colonCount != 1)
                throw new ArgumentException("Invalid header.", nameof(requestText));
            
            // Tomar los valores a la izquierda y derecha de :
            int idx = line.IndexOf(':');
            string name = line.Substring(0, idx).Trim();
            string value = line.Substring(idx + 1).Trim();
            
            if (name.Length == 0 || value.Length == 0)
                throw new ArgumentException($"Invalid header.", nameof(requestText));

            headers.Add(name, value);
        }

        // BODY
        string? body = BlankLine ? string.Join("\n", lines.Skip(1)) : null;

        return new HttpRequest
        {
            Method = method,
            RequestTarget = target,
            Headers = headers,
            Protocol = version,
            Body = body
        };
    }
}
