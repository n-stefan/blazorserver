using System.Threading.Tasks;

namespace Data
{
    public interface ICookieRepository
    {
        Task<Cookie> GetRandomCookie();
    }
}
