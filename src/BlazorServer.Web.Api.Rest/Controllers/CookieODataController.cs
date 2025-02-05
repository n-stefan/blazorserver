﻿
namespace BlazorServer.Web.Api.Rest.Controllers;

[Route("/v1/odata")]
public class CookieODataController(IRepository<Cookie> repository, ILogger<CookieODataController> logger) : ODataController
{
  [HttpGet("cookie")]
  [EnableQuery]
  public async Task<ActionResult<Cookie>> GetRandomCookieAsync()
  {
    var cookie = await repository.GetRandomAsync();
    return (cookie == null) ?
      NotFound() :
      Ok(cookie);
  }
}
