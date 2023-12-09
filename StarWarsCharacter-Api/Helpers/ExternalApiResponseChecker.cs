using System.Net;

namespace StarWarsCharacter_Api.Helpers;

public static class ExternalApiResponseChecker
{
    public static void CheckResponseStatusCode(HttpResponseMessage response)
    {
        if (response.StatusCode > HttpStatusCode.NotFound)
        {
            throw new SWCApiException($"External api response error", response.StatusCode);
        }
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            throw new SWCApiException($"Not Found", response.StatusCode);
        }
    }
}
