using HttpMessageParser.Models;

namespace HttpMessageParser
{
    /// <summary>
    /// Defines a method for serializing an <see cref="HttpResponse"/> to a string representation.
    /// </summary>
    public interface IResponseWriter
    {
        /// <summary>
        /// Writes the specified <see cref="HttpResponse"/> to a string representation.
        /// </summary>
        /// <param name="response">A populated <c>HttpResponse</c> instance ready to be serialized</param>
        /// <returns>
        /// A string representation of the <paramref name="response"/> instance.
        /// </returns>
        public string WriteResponse(HttpResponse response);
    }
}
