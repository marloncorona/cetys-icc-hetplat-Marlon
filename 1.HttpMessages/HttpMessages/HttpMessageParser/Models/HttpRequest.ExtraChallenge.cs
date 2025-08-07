namespace HttpMessageParser.Models
{
    public partial class HttpRequest
    {
        /// <summary>
        /// Extracts the query parameters from the <c>RequestTarget</c> property.
        /// </summary>
        /// <remarks>
        /// If no query parameters are present, this method will return an empty dictionary.
        /// </remarks>
        /// <returns>
        /// A dictionary where the keys are the parameter names and the values are the parameter values.
        /// </returns>
        /// <exception cref="FormatException">If the <c>RequestTarget</c> contains query parameters, but they are malformed.</exception>"
        public Dictionary<string, string> GetQueryParameters()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Extracts the form data from the request body. This supports both the "application/x-www-form-urlencoded" 
        /// and the "multipart/form-data" content types.
        /// </summary>
        /// <remarks>
        /// If the request has no body or the body does not contain form data, this method will return an empty dictionary.
        /// </remarks>
        /// <returns>
        /// A dictionary where the keys are the form field names and the values are the form field values.
        /// </returns>
        /// <exception cref="FormatException">If the contents of the body are not in the correct format.</exception>
        public Dictionary<string, string> GetFormData()
        {
            throw new NotImplementedException();
        }
    }
}
