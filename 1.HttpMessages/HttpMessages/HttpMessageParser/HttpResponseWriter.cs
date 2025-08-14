using System.Text;
using HttpMessageParser.Models;

namespace HttpMessageParser;

public class HttpResponseWriter : IResponseWriter 
{
    public string WriteResponse(HttpResponse response)
    {   
        if (response is null) 
            throw new ArgumentNullException(nameof(response));
        if (response.Protocol is null)
            throw new ArgumentException("Protocol cannot be null.", nameof(response));
        if (response.StatusCode == 0)
            throw new ArgumentException("StatusCode cannot be empty.", nameof(response));
        if (string.IsNullOrWhiteSpace(response.StatusText))
            throw new ArgumentException("StatusText cannot be null or empty.", nameof(response));
        if (response.Headers is null)
            throw new ArgumentException("Headers cannot be null.", nameof(response));
        
        // Varible donde se agregaran los elementos de la respuesta
        var respBasica = new StringBuilder(); 
        
        // Start line
        respBasica.Append(response.Protocol).Append(' ') // HTTP/1.X
            .Append(response.StatusCode).Append(' ') // 2XX 3XX 4XX
            .Append(response.StatusText).Append("\n").Append("\r\n");// Mensaje de error
        
        // Headers
        foreach (var kv in response.Headers)
        {
            if (string.IsNullOrEmpty(kv.Key) || kv.Value == null)
                throw new ArgumentException("Headers cannot be null or empty.", nameof(response));
            if (kv.Key.Contains(":") || kv.Key.Contains("\r") || kv.Key.Contains("\n")|| kv.Value.Contains("\r") || kv.Value.Contains("\n"))
                throw new ArgumentException("Headers cannot contain:or contain:.", nameof(response));
            
            respBasica.Append(kv.Key).Append(": ").Append(kv.Value).Append("\r\n");
        }

        // BODY
        respBasica.Append("\n"); // Blank Line -> Body
        if (response.Body != null)
            respBasica.Append(response.Body);
        
        return respBasica.ToString();
    }
}