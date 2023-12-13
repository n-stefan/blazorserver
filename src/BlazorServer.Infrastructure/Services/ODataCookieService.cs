
namespace BlazorServer.Infrastructure.Services;

public class ODataCookieService(HttpClient httpClient) : BaseRestCookieService(httpClient, new Uri("/v1/odata/cookie", UriKind.Relative))
{
}
