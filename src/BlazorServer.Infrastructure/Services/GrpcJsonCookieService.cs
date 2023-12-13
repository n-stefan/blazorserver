
namespace BlazorServer.Infrastructure.Services;

public class GrpcJsonCookieService(HttpClient httpClient) : BaseRestCookieService(httpClient, new Uri("/v1/getrandomcookie", UriKind.Relative))
{
}
