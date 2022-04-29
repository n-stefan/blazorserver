
namespace BlazorServer.Web.Api.Grpc.Services;

public class CookieService : CookieContract.CookieContractBase
{
    private readonly IRepository<Cookie> _repository;
    private readonly ILogger<CookieService> _logger;

    public CookieService(IRepository<Cookie> repository, ILogger<CookieService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public override async Task<CookieResponse> GetRandomCookie(Empty request, ServerCallContext context)
    {
        var cookie = await _repository.GetRandom();
        return (cookie == null) ?
            throw new RpcException(new Status(StatusCode.NotFound, "Cookie not found.")) :
            new CookieResponse { Id = cookie.Id, Message = cookie.Message };
    }
}
