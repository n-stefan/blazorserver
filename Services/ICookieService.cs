
namespace Services;

public interface ICookieService
{
    Task<CookieDto> GetRandomCookie();
}
