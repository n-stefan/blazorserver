﻿using Data;
using System.Threading.Tasks;

namespace Services
{
    public class DirectCookieService : ICookieService
    {
        private readonly ICookieRepository _repository;

        public DirectCookieService(ICookieRepository repository) =>
            _repository = repository;

        public async Task<CookieDto> GetRandomCookie()
        {
            var cookie = await _repository.GetRandomCookie();
            return (cookie == null) ? null : new CookieDto(cookie.Id, cookie.Message);
        }
    }
}