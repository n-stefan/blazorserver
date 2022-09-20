
namespace BlazorServer.Infrastructure.Services;

public class RestCookieService : BaseRestCookieService
{
  public RestCookieService(HttpClient httpClient) : base(httpClient, "/v1/cookie/random") { }
}
