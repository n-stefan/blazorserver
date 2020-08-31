using Data;
using System;
using System.Threading.Tasks;

namespace Services
{
    public class DirectCookieService : ICookieService
    {
        private readonly IRepository<Cookie> _repository;

        public DirectCookieService(IRepository<Cookie> repository) =>
            _repository = repository;

        public async Task<CookieDto> GetRandomCookie()
        {
            try
            {
                var cookie = await _repository.GetRandom();
                return (cookie == null) ? null : new CookieDto(cookie.Id, cookie.Message);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
