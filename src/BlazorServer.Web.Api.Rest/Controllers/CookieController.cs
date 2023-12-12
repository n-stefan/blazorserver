
namespace BlazorServer.Web.Api.Rest.Controllers;

[ApiController]
[Route("/v1/[controller]")]
public class CookieController(IRepository<Cookie> repository, ILogger<CookieController> logger) : ControllerBase
{
    [HttpGet("random")]
    public async Task<ActionResult<Cookie>> GetRandomCookie()
    {
        var cookie = await repository.GetRandom();
        return (cookie == null) ?
            NotFound() :
            Ok(cookie);
    }
}
