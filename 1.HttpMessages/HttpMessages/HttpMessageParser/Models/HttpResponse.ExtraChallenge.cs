namespace HttpMessageParser.Models
{
    public partial class HttpResponse
    {
        /// <summary>
        /// Returns a boolean indicating whether the response is successful.
        /// </summary>
        /// <returns>
        /// True if the status code indicates a success, otherwise false.
        /// </returns>
        public bool IsSuccess()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a boolean indicating whether the response is a client error.
        /// </summary>
        /// <returns>
        /// True if the status code indicates a client error, otherwise false.
        /// </returns>
        public bool IsClientError()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a boolean indicating whether the response is a server error.
        /// </summary>
        /// <returns>
        /// True if the status code indicates a server error, otherwise false.
        /// </returns>
        public bool IsServerError()
        {
            throw new NotImplementedException();
        }
    }
}
