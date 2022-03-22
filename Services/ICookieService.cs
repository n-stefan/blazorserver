using System.Threading.Tasks;

namespace Services;

public interface ICookieService
{
    Task<CookieDto> GetRandomCookie();
}
