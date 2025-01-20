
namespace BlazorServer.Web.Api.Wcf.Services;

[ServiceContract]
public interface ICookieService
{
  [OperationContract]
  Task<CookieResponse> GetRandomCookie();
}
