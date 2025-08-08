# Activity 1: HTTP Message Parsing

## Introduction

In this activity, you will implement the necessary code to parse and write HTTP messages.

You are provided with 2 classes: [`HttpRequest`](https://github.com/ludanortmun/cetys-icc-hetplat/tree/main/1.HttpMessages/HttpMessages/HttpMessageParser/Models/HttpRequest.cs) and [`HttpResponse`](https://github.com/ludanortmun/cetys-icc-hetplat/tree/main/1.HttpMessages/HttpMessages/HttpMessageParser/Models/HttpResponse.cs). These are simple classes to represent the structure of 
an HTTP request and response, respectively.

You are also provided with 2 interfaces: [`IRequestParser`](https://github.com/ludanortmun/cetys-icc-hetplat/tree/main/1.HttpMessages/HttpMessages/HttpMessageParser/IRequestParser.cs) and [`IResponseWriter`](https://github.com/ludanortmun/cetys-icc-hetplat/tree/main/1.HttpMessages/HttpMessages/HttpMessageParser/IResponseWriter.cs). These interfaces define the methods that you need to implement in this activity; one for reading a string and converting it to an `HttpRequest`, and another for writing an `HttpResponse` to a string.

For a better understanding of the HTTP message structure, you can refer to the [HTTP Messages](https://developer.mozilla.org/en-US/docs/Web/HTTP/Guides/Messages) documentation.


## Instructions

1. Create a new class called `HttpRequestParser` that implements the `IRequestParser` interface. 
    1. Create the new class in the same directory as the interface. 
	1. Ensure that your class is public.
	1. Implement the `ParseRequest` method in your `HttpRequestParser` class. This method should take a string representing an HTTP request and return an `HttpRequest` object.
		2. If the input string is null, it should throw an `ArgumentNullException`
		3. If the input string is empty, it should throw an `ArgumentException`
		4. If the input string is not in valid HTTP format or it's missing required fields, it should throw an `ArgumentException`. For simplicity, the format validation should only consider the following:
			5. The HTTP method is present, regardless of its actual value
			6. The Request Target contains at least one "/" character
			7. The HTTP protocol version should be present and start with "HTTP"
			8. Each HTTP header line should include exactly ":" character; and there needs to be text before and after it
	1. [Optional] Update the [`Setup` method in the `RequestParserTests` class](https://github.com/ludanortmun/cetys-icc-hetplat/tree/main/1.HttpMessages/HttpMessages/HttpMessageParser.Tests/RequestParserTests.cs?plain=1#L13) so that the `requestParser` field is initialized with an instance of your `HttpRequestParser` class. 
		- This will allow you to use the existing tests to verify your implementation.
		- DO NOT modify the tests themselves; only the setup method.
2. Create a new class called `HttpResponseWriter` that implements the `IResponseWriter` interface. 
	1. Create the new class in the same directory as the interface.
	1. Ensure that your class is public.
	1. Implement the `WriteResponse` method in your `HttpResponseWriter` class. This method should take an `HttpResponse` object and return a string representing the HTTP response.
		2. If the input object is null, it should throw an `ArgumentNullException`
		3. If any of the required properties in the response object are null, it should throw an `ArgumentException` 
	1. [Optional] Update the [`Setup` method in the `ResponseWriterTests` class](https://github.com/ludanortmun/cetys-icc-hetplat/tree/main/1.HttpMessages/HttpMessages/HttpMessageParser.Tests/ResponseWriterTests.cs#L13) so that the `responseWriter` field is initialized with an instance of your `HttpResponseWriter` class.
		- This will allow you to use the existing tests to verify your implementation.
		- DO NOT modify the tests themselves; only the setup method.

## Extra credits challenge

If you want to challenge yourself, you can implement the following:

- Implement the `GetHeaderValue(string headerName)`, `GetQueryParams()` and `GetFormData()` methods in the `HttpRequest` class. The signature for these methods is already defined in the [HttpRequest.ExtraChallenge.cs](https://github.com/ludanortmun/cetys-icc-hetplat/blob/main/1.HttpMessages/HttpMessages/HttpMessageParser/Models/HttpRequest.ExtraChallenge.cs) file.
	- `GetHeaderValue(string headerName)` should return the value of the specified header from the request. If the header does not exist, it should return `null`. If the `headerName` is null or empty, it should throw an `ArgumentNullException`. The header names are case-insensitive, so you should handle that accordingly.
	- `GetQueryParams()` should return a dictionary containing the query parameters from the request URL. The keys should be the parameter names and the values should be the parameter values. If there are no query parameters, it should return an empty dictionary. If the request contains a malformed query string, it should throw a `FormatException`.
	- `GetFormData()` should return a dictionary containing the form data from the request body. The keys should be the form field names and the values should be the form field values. If there is no form data, it should return an empty dictionary. If the request body is not in a valid format, it should throw a `FormatException`. This method only supports the `application/x-www-form-urlencoded` and `multipart/form-data` content types. If the request body is not in any of these formats, it should return an empty dictionary.
	- You can validate your implementation by running the the tests defined in the [`HttpRequestExtraChallengeTests`](https://github.com/ludanortmun/cetys-icc-hetplat/tree/main/1.HttpMessages/HttpMessages/HttpMessageParser.Tests/HttpRequest.ExtraChallengeTests.cs) class.
- Implement the `GetHeaderValue(string headerName)`, `IsSuccess()`, `IsClientError()`, and `IsServerError()` methods in the `HttpResponse` class. The signatures for these methods are already defined in the [HttpResponse.ExtraChallenge.cs](https://github.com/ludanortmun/cetys-icc-hetplat/blob/main/1.HttpMessages/HttpMessages/HttpMessageParser/Models/HttpResponse.ExtraChallenge.cs) file.
	- `GetHeaderValue(string headerName)` should return the value of the specified header from the request. If the header does not exist, it should return `null`. If the `headerName` is null or empty, it should throw an `ArgumentNullException`. The header names are case-insensitive, so you should handle that accordingly.
	- `IsSuccess()` should return `true` if the status code of the response indicates a successful response, and `false` otherwise.
	- `IsClientError()` should return `true` if the status code of the response indicates a client error, and `false` otherwise.
	- `IsServerError()` should return `true` if the status code of the response indicates a server error, and `false` otherwise.
	- You can validate your implementation by running the tests defined in the [`HttpResponseExtraChallengeTests`](https://github.com/ludanortmun/cetys-icc-hetplat/tree/main/1.HttpMessages/HttpMessages/HttpMessageParser.Tests/HttpResponse.ExtraChallengeTests.cs) class.

As you may have noticed, `HttpRequest` and `HttpResponse` classes are partial classes, which means that you can add additional functionality to them in separate files without modifying the original. In this case, the extra challenge methods are defined in separate files to keep the original classes clean and focused on their primary responsibilities. As a benefit to this, the methods defined in the extra challenge files will be able to access the properties defined in the original classes; for example, the `GetHeaderValue` method can access the `Headers` property of the `HttpRequest` class.

## Running the tests

Unit tests are provided to verify your implementation. You can run the tests using the test runner in your IDE or by using the command line.

To run the tests from the command line, navigate to the root directory of the project and run the following command:
```bash
dotnet test
```

To run the tests from Visual Studio, you can use the Test Explorer window. You can open it by going to `Test > Windows > Test Explorer` in the menu bar. Once the Test Explorer window is open, you can run all tests by clicking the "Run All" button or by right-clicking on a specific test and selecting "Run Selected Tests".