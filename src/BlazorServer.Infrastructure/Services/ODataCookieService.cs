
namespace BlazorServer.Infrastructure.Services;

public class ODataCookieService : BaseRestCookieService
{
  public ODataCookieService(HttpClient httpClient) : base(httpClient, "/v1/odata/cookie") { }
}
