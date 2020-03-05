using Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CookieController : ControllerBase
    {
        private readonly ICookieRepository _repository;

        public CookieController(ICookieRepository repository) =>
            _repository = repository;

        [HttpGet("random")]
        public async Task<Cookie> GetRandomCookie() =>
            await _repository.GetRandomCookie();
    }
}
