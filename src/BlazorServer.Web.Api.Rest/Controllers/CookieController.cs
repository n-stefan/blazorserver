
namespace BlazorServer.Web.Api.Rest.Controllers;

[ApiController]
[Route("[controller]")]
public class CookieController : ControllerBase
{
    private readonly IRepository<Cookie> _repository;
    private readonly ILogger<CookieController> _logger;

    public CookieController(IRepository<Cookie> repository, ILogger<CookieController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpGet("random")]
    public async Task<ActionResult<Cookie>> GetRandomCookie()
    {
        var cookie = await _repository.GetRandom();
        return (cookie == null) ?
            NotFound() :
            Ok(cookie);
    }
}
