using Microsoft.EntityFrameworkCore;
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

        public Task<Cookie> GetRandomCookie()
        {
            var cookies = _context.Cookies.AsNoTracking();
            var id = _random.Next(1, cookies.Count() + 1);
            return cookies.SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
