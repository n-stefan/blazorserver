
namespace BlazorServer.Core.Interfaces;

public interface ICookieService
{
  Task<CookieDto> GetRandomCookieAsync();
}
