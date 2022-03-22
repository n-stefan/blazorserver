
namespace Rest.Controllers;

[ApiController]
[Route("[controller]")]
public class CookieController : ControllerBase
{
    private readonly IRepository<Cookie> _repository;

    public CookieController(IRepository<Cookie> repository) =>
        _repository = repository;

    [HttpGet("random")]
    public async Task<ActionResult<Cookie>> GetRandomCookie()
    {
        var cookie = await _repository.GetRandom();
        return (cookie == null) ?
            NotFound() :
            Ok(cookie);
    }
}
