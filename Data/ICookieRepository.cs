using System.Threading.Tasks;

namespace Data
{
    public interface ICookieRepository
    {
        ValueTask<Cookie> GetRandomCookie();
    }
}