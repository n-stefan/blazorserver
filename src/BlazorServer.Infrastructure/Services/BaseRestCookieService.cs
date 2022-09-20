
using Cookie = BlazorServer.Core.Entities.Cookie;
using System.Net;

namespace BlazorServer.Infrastructure.Services;

public abstract class BaseRestCookieService : ICookieService
{
  private readonly HttpClient _httpClient;
  private readonly string _requestUri;

  protected BaseRestCookieService(HttpClient httpClient, string requestUri)
  {
    _httpClient = httpClient;
    _requestUri = requestUri;
  }

  public async Task<CookieDto> GetRandomCookie()
  {
    try
    {
      var response = await _httpClient.GetAsync(_requestUri);
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
      };
    }
    catch (Exception)
    {
      return new CookieDto(CookieDto.AnErrorOccurred);
    }
  }
}
