
using Cookie = BlazorServer.Core.Entities.Cookie;
using System.Net;

namespace BlazorServer.Infrastructure.Services;

public abstract class BaseRestCookieService(HttpClient httpClient, Uri requestUri) : ICookieService
{
  public async Task<CookieDto> GetRandomCookieAsync()
  {
    try
    {
      var response = await httpClient.GetAsync(requestUri);
      switch (response.StatusCode)
      {
        case HttpStatusCode.OK:
          var cookie = await response.Content.ReadFromJsonAsync<Cookie>();
          return (cookie != null) ?
            new CookieDto(cookie.Id, cookie.Message) :
            new CookieDto(CookieDto.AnErrorOccurred);
        case HttpStatusCode.NotFound:
          return new CookieDto(CookieDto.CookieNotFound);
        default:
          return new CookieDto(CookieDto.AnErrorOccurred);
      }
    }
    catch (Exception)
    {
      return new CookieDto(CookieDto.AnErrorOccurred);
    }
  }
}
