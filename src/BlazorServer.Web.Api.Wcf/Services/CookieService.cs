
namespace BlazorServer.Web.Api.Wcf.Services;

public partial class CookieService : ICookieService
{
  public async Task<CookieResponse> GetRandomCookie([Injected] IRepository<Cookie> repository)
  {
    var cookie = await repository.GetRandom();
    return (cookie == null) ?
      throw new FaultException<CookieFault>(new CookieFault { Text = "Cookie not found." }, new FaultReason("Cookie not found.")) :
      new CookieResponse { Id = cookie.Id, Message = cookie.Message };
  }
}
