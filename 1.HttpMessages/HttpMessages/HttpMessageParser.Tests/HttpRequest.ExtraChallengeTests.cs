using HttpMessageParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpMessageParser.Tests
{
    public class HttpRequestExtraChallengeTests
    {
        [Test]
        public void GetQueryParameters_ReturnsEmptyDictionaryForNoQueryString()
        {
            HttpRequest request = new HttpRequest
            {
                Method = "GET",
                RequestTarget = "/path",
                Protocol = "HTTP/1.1",
                Headers = new Dictionary<string, string>(),
                Body = null
            };

            IDictionary<string, string> queryParams = request.GetQueryParameters();

            Assert.IsNotNull(queryParams);
            Assert.IsEmpty(queryParams);
        }

        [Test]
        public void GetQueryParameters_ReturnsParsedParameters()
        {
            HttpRequest request = new HttpRequest
            {
                Method = "GET",
                RequestTarget = "/path?param1=value1&param2=value2",
                Protocol = "HTTP/1.1",
                Headers = new Dictionary<string, string>(),
                Body = null
            };

            IDictionary<string, string> queryParams = request.GetQueryParameters();

            Assert.IsNotNull(queryParams);
            Assert.That(queryParams.Count, Is.EqualTo(2));
            Assert.That(queryParams["param1"], Is.EqualTo("value1"));
            Assert.That(queryParams["param2"], Is.EqualTo("value2"));
        }

        [Test]
        public void GetQueryParameters_ThrowsFormatExceptionIfMalformedQueryString()
        {
            HttpRequest request = new HttpRequest
            {
                Method = "GET",
                RequestTarget = "/path?param1=value1&param2", // Missing value for param2
                Protocol = "HTTP/1.1",
                Headers = new Dictionary<string, string>(),
                Body = null
            };

            Assert.Throws<FormatException>(() => request.GetQueryParameters());
        }

        [Test]
        public void GetFormData_ReturnsEmptyDictionaryForNoBody()
        {
            HttpRequest request = new HttpRequest
            {
                Method = "POST",
                RequestTarget = "/submit",
                Protocol = "HTTP/1.1",
                Headers = new Dictionary<string, string>(),
                Body = null
            };

            IDictionary<string, string> formData = request.GetFormData();

            Assert.IsNotNull(formData);
            Assert.IsEmpty(formData);
        }

        [Test]
        public void GetFormData_ReturnsParsedFormDataForFormUrlencoded()
        {
            HttpRequest request = new HttpRequest
            {
                Method = "POST",
                RequestTarget = "/submit",
                Protocol = "HTTP/1.1",
                Headers = new Dictionary<string, string>
                {
                    { "Content-Type", "application/x-www-form-urlencoded" }
                },
                Body = "field1=value1&field2=value2"
            };

            IDictionary<string, string> formData = request.GetFormData();

            Assert.IsNotNull(formData);
            Assert.That(formData.Count, Is.EqualTo(2));
            Assert.That(formData["field1"], Is.EqualTo("value1"));
            Assert.That(formData["field2"], Is.EqualTo("value2"));
        }

        [Test]
        public void GetFormData_ThrowsFormatExceptionIfMalformedFormUrlencoded()
        {
            HttpRequest request = new HttpRequest
            {
                Method = "POST",
                RequestTarget = "/submit",
                Protocol = "HTTP/1.1",
                Headers = new Dictionary<string, string>
                {
                    { "Content-Type", "application/x-www-form-urlencoded" }
                },
                Body = "field1=value1&field2" // Missing value for field2
            };

            Assert.Throws<FormatException>(() => request.GetFormData());
        }

        [Test]
        public void GetFormData_ReturnsEmptyDictionaryForBodyWithUnsupportedContentType()
        {
            HttpRequest request = new HttpRequest
            {
                Method = "POST",
                RequestTarget = "/submit",
                Protocol = "HTTP/1.1",
                Headers = new Dictionary<string, string>
                {
                    { "Content-Type", "text/plain" }
                },
                Body = "This is not form data, but the request is formed correctly."
            };

            IDictionary<string, string> formData = request.GetFormData();

            Assert.IsNotNull(formData);
            Assert.IsEmpty(formData);
        }

        [Test]
        public void GetFormData_ReturnsParsedFormDataForMultipartFormData()
        {
            HttpRequest request = new HttpRequest
            {
                Method = "POST",
                RequestTarget = "/submit",
                Protocol = "HTTP/1.1",
                Headers = new Dictionary<string, string>
                {
                    { "Content-Type", "multipart/form-data;boundary=1234567890" }
                },
                Body = "--1234567890\n" +
                       "Content-Disposition: form-data; name=\"field1\"\n\n" +
                       "value1\n" +
                       "--1234567890\n" +
                       "Content-Disposition: form-data; name=\"field2\"\n\n" +
                       "value2\n" +
                       "--1234567890--"
            };

            IDictionary<string, string> formData = request.GetFormData();

            Assert.IsNotNull(formData);
            Assert.That(formData.Count, Is.EqualTo(2));
            Assert.That(formData["field1"], Is.EqualTo("value1"));
            Assert.That(formData["field2"], Is.EqualTo("value2"));
        }

        [Test]
        public void GetFormData_ThrowsFormatExceptionIfMalformedMultipartFormData()
        {
            HttpRequest request = new HttpRequest
            {
                Method = "POST",
                RequestTarget = "/submit",
                Protocol = "HTTP/1.1",
                Headers = new Dictionary<string, string>
                {
                    { "Content-Type", "multipart/form-data; boundary=1234567890" }
                },
                Body = "--1234567890\n" +
                       "Content-Disposition: form-data; name=\"field1\"\n\n" +
                       "value1\n" +
                       "--1234567890\n" +
                       "Content-Disposition: form-data\n\n" + // Missing name for field2
                       "value2\n" +
                       "--1234567890--" 
            };
            Assert.Throws<FormatException>(() => request.GetFormData());
        }
    }
}
