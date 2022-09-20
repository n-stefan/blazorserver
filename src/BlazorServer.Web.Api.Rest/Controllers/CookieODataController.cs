
namespace BlazorServer.Web.Api.Rest.Controllers;

[Route("/v1/odata")]
public class CookieODataController : ODataController
{
  private readonly IRepository<Cookie> _repository;
  private readonly ILogger<CookieODataController> _logger;

  public CookieODataController(IRepository<Cookie> repository, ILogger<CookieODataController> logger)
  {
    _repository = repository;
    _logger = logger;
  }

  [HttpGet("cookie")]
  [EnableQuery]
  public async Task<ActionResult<Cookie>> GetRandomCookie()
  {
    var cookie = await _repository.GetRandom();
    return (cookie == null) ?
      NotFound() :
      Ok(cookie);
  }
}
