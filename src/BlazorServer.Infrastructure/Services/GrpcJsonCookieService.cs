
namespace BlazorServer.Infrastructure.Services;

public class GrpcJsonCookieService(HttpClient httpClient) : BaseRestCookieService(httpClient, "/v1/getrandomcookie")
{
}
