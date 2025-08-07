using HttpMessageParser.Models;

namespace HttpMessageParser.Tests
{
    public class HttpResponseExtraChallengeTests
    {
        [Test]
        public void GetHeaderValue_ThrowsArgumentExceptionForNullHeaderName()
        {
            HttpResponse response = new HttpResponse
            {
                Protocol = "HTTP/1.1",
                StatusCode = 200,
                StatusText = "OK",
                Headers = new Dictionary<string, string>(),
            };

            Assert.Throws<ArgumentException>(() => response.GetHeaderValue(null));
        }

        [Test]
        public void GetHeaderValue_ThrowsArgumentExceptionForEmptyHeaderName()
        {
            HttpResponse response = new HttpResponse
            {
                Protocol = "HTTP/1.1",
                StatusCode = 200,
                StatusText = "OK",
                Headers = new Dictionary<string, string>(),
            };

            Assert.Throws<ArgumentException>(() => response.GetHeaderValue(string.Empty));
        }

        [Test]
        public void GetHeaderValue_ReturnsNullForNonExistentHeader()
        {
            HttpResponse response = new HttpResponse
            {
                Protocol = "HTTP/1.1",
                StatusCode = 200,
                StatusText = "OK",
                Headers = new Dictionary<string, string>(),
            };

            string headerValue = response.GetHeaderValue("Non-Existent-Header");

            Assert.IsNull(headerValue);
        }

        [Test]
        public void GetHeaderValue_ReturnsCorrectValueForExistingHeader()
        {
            HttpResponse response = new HttpResponse
            {
                Protocol = "HTTP/1.1",
                StatusCode = 200,
                StatusText = "OK",
                Headers = new Dictionary<string, string>
                {
                    { "Content-Type", "application/json" }
                },
            };

            string headerValue = response.GetHeaderValue("Content-Type");

            Assert.That(headerValue, Is.EqualTo("application/json"));
        }

        [Test]
        public void GetHeaderValue_IsCaseInsensitive()
        {
            HttpResponse response = new HttpResponse
            {
                Protocol = "HTTP/1.1",
                StatusCode = 200,
                StatusText = "OK",
                Headers = new Dictionary<string, string>
                {
                    { "Content-Type", "application/json" }
                },
            };

            string headerValue = response.GetHeaderValue("content-type");

            Assert.That(headerValue, Is.EqualTo("application/json"));
        }

        [Test]
        public void IsSuccess_ReturnsTrueForSuccessfulStatusCodes()
        {
            for (int statusCode = 200; statusCode < 300; statusCode++)
            {
                HttpResponse response = new HttpResponse
                {
                    Protocol = "HTTP/1.1",
                    StatusCode = statusCode,
                    StatusText = "OK",
                    Headers = new Dictionary<string, string>(),
                };
                Assert.IsTrue(response.IsSuccess());
            }
        }

        [Test]
        public void IsSuccess_ReturnsFalseForErrorStatusCodes()
        {
            for (int statusCode = 400; statusCode < 600; statusCode++)
            {
                HttpResponse response = new HttpResponse
                {
                    Protocol = "HTTP/1.1",
                    StatusCode = statusCode,
                    StatusText = "Error",
                    Headers = new Dictionary<string, string>(),
                };
                Assert.IsFalse(response.IsSuccess());
            }
        }

        [Test]
        public void IsClientError_ReturnsTrueForClientErrorStatusCodes()
        {
            for (int statusCode = 400; statusCode < 500; statusCode++)
            {
                HttpResponse response = new HttpResponse
                {
                    Protocol = "HTTP/1.1",
                    StatusCode = statusCode,
                    StatusText = "Client Error",
                    Headers = new Dictionary<string, string>(),
                };
                Assert.IsTrue(response.IsClientError());
            }
        }

        [Test]
        public void IsClientError_ReturnsFalseForNonClientErrorStatusCodes()
        {
            for (int statusCode = 100; statusCode < 400; statusCode++)
            {
                HttpResponse response = new HttpResponse
                {
                    Protocol = "HTTP/1.1",
                    StatusCode = statusCode,
                    StatusText = "Not Client Error",
                    Headers = new Dictionary<string, string>(),
                };
                Assert.IsFalse(response.IsClientError());
            }

            for (int statusCode = 500; statusCode < 600; statusCode++)
            {
                HttpResponse response = new HttpResponse
                {
                    Protocol = "HTTP/1.1",
                    StatusCode = statusCode,
                    StatusText = "Server Error",
                    Headers = new Dictionary<string, string>(),
                };
                Assert.IsFalse(response.IsClientError());
            }
        }

        [Test]
        public void IsServerError_ReturnsTrueForServerErrorStatusCodes()
        {
            for (int statusCode = 500; statusCode < 600; statusCode++)
            {
                HttpResponse response = new HttpResponse
                {
                    Protocol = "HTTP/1.1",
                    StatusCode = statusCode,
                    StatusText = "Server Error",
                    Headers = new Dictionary<string, string>(),
                };
                Assert.IsTrue(response.IsServerError());
            }
        }

        [Test]
        public void IsServerError_ReturnsFalseForNonServerErrorStatusCodes()
        {
            for (int statusCode = 100; statusCode < 500; statusCode++)
            {
                HttpResponse response = new HttpResponse
                {
                    Protocol = "HTTP/1.1",
                    StatusCode = statusCode,
                    StatusText = "Not Server Error",
                    Headers = new Dictionary<string, string>(),
                };
                Assert.IsFalse(response.IsServerError());
            }
        }
    }
}
