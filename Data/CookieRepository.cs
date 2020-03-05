using System;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class CookieRepository : ICookieRepository
    {
        private readonly CookieDbContext _context;
        private readonly Random _random;

        public CookieRepository(CookieDbContext context)
        {
            _context = context;
            _random = new Random();
        }

        public ValueTask<Cookie> GetRandomCookie()
        {
            var id = _random.Next(1, _context.Cookies.Count() + 1);
            return _context.Cookies.FindAsync(id);
        }
    }
}
