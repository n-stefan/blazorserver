
namespace BlazorServer.Infrastructure.Services;

public class RestCookieService(HttpClient httpClient) : BaseRestCookieService(httpClient, "/v1/cookie/random")
{
}
