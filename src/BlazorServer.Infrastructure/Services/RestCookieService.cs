
namespace BlazorServer.Infrastructure.Services;

public class RestCookieService(HttpClient httpClient) : BaseRestCookieService(httpClient, new Uri("/v1/cookie/random", UriKind.Relative))
{
}
