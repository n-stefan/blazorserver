﻿
namespace BlazorServer.Core.Services;

public class DirectCookieService(IRepository<Cookie> repository) : ICookieService
{
  public async Task<CookieDto> GetRandomCookie()
  {
    try
    {
      var cookie = await repository.GetRandom();
      return (cookie == null) ?
          new CookieDto(CookieDto.CookieNotFound) :
          new CookieDto(cookie.Id, cookie.Message);
    }
    catch (Exception)
    {
      return new CookieDto(CookieDto.AnErrorOccurred);
    }
  }
}
