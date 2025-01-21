
namespace BlazorServer.Web.Api.Grpc.Services;

public class CookieService(IRepository<Cookie> repository, ILogger<CookieService> logger) : CookieContract.CookieContractBase
{
    public override async Task<CookieResponse> GetRandomCookie(Empty request, ServerCallContext context)
    {
        var cookie = await repository.GetRandomAsync();
        return (cookie == null) ?
            throw new RpcException(new Status(StatusCode.NotFound, "Cookie not found.")) :
            new CookieResponse { Id = cookie.Id, Message = cookie.Message };
    }
}
