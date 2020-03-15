using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class CookieRepository : ICookieRepository
    {
        private static readonly Func<CookieDbContext, int> _countQuery = EF.CompileQuery((CookieDbContext context) =>
            context.Cookies.AsNoTracking().Count());
        private static readonly Func<CookieDbContext, int, Task<Cookie>> _singleQuery = EF.CompileAsyncQuery((CookieDbContext context, int id) =>
            context.Cookies.AsNoTracking().SingleOrDefault(c => c.Id == id));

        private readonly CookieDbContext _context;
        private readonly Random _random;

        public CookieRepository(CookieDbContext context)
        {
            _context = context;
            _random = new Random();
        }

        public Task<Cookie> GetRandomCookie()
        {
            var id = _random.Next(1, _countQuery(_context) + 1);
            return _singleQuery(_context, id);
        }
    }
}
