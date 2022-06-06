
using Cookie = BlazorServer.Core.Entities.Cookie;
using System.Net;

namespace BlazorServer.Infrastructure.Services;

public class GrpcJsonCookieService : ICookieService
{
  private readonly HttpClient _httpClient;

  public GrpcJsonCookieService(HttpClient httpClient) =>
      _httpClient = httpClient;

  public async Task<CookieDto> GetRandomCookie()
  {
    try
    {
      var response = await _httpClient.GetAsync("/v1/getrandomcookie");
      switch (response.StatusCode)
      {
        case HttpStatusCode.OK:
          var cookie = await response.Content.ReadFromJsonAsync<Cookie>();
          return new CookieDto(cookie.Id, cookie.Message);
        case HttpStatusCode.NotFound:
          return new CookieDto(CookieDto.CookieNotFound);
        default:
          return new CookieDto(CookieDto.AnErrorOccurred);
      };
    }
    catch (Exception)
    {
      return new CookieDto(CookieDto.AnErrorOccurred);
    }
  }
}
