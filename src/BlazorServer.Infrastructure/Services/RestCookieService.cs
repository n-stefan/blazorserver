
using Cookie = BlazorServer.Core.Entities.Cookie;
using System.Net;

namespace BlazorServer.Infrastructure.Services;

public class RestCookieService : ICookieService
{
  private readonly HttpClient _httpClient;

  public RestCookieService(HttpClient httpClient) =>
      _httpClient = httpClient;

  public async Task<CookieDto> GetRandomCookie()
  {
    try
    {
      var response = await _httpClient.GetAsync("cookie/random");
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
