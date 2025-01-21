
namespace BlazorServer.Web.Api.Rest.Controllers;

[ApiController]
[Route("/v1/[controller]")]
public class CookieController(IRepository<Cookie> repository, ILogger<CookieController> logger) : ControllerBase
{
    [HttpGet("random")]
    public async Task<ActionResult<Cookie>> GetRandomCookieAsync()
    {
        var cookie = await repository.GetRandomAsync();
        return (cookie == null) ?
            NotFound() :
            Ok(cookie);
    }
}
