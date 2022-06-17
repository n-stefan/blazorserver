
namespace BlazorServer.Infrastructure.Services;

public class GrpcJsonCookieService : BaseRestCookieService
{
  public GrpcJsonCookieService(HttpClient httpClient) : base(httpClient, "/v1/getrandomcookie") { }
}
