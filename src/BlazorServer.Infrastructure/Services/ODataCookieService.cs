
namespace BlazorServer.Infrastructure.Services;

public class ODataCookieService(HttpClient httpClient) : BaseRestCookieService(httpClient, "/v1/odata/cookie")
{
}
