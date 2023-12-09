using System.Net;

namespace StarWarsCharacter_Api.Helpers;

public class SWCApiException : Exception
{
    public HttpStatusCode HttpStatusCode { get; set; }
    public SWCApiException(string message) : base(message) { }
    public SWCApiException(string message, HttpStatusCode statusCode) : base(message)
    {
        HttpStatusCode = statusCode;
    }
}
