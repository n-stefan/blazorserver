
namespace Grpc;

public class CookieService : CookieContract.CookieContractBase
{
    private readonly IRepository<Data.Cookie> _repository;

    public CookieService(IRepository<Data.Cookie> repository) =>
        _repository = repository;

    public override async Task<Cookie> GetRandomCookie(Empty request, ServerCallContext context)
    {
        var cookie = await _repository.GetRandom();
        return (cookie == null) ?
            throw new RpcException(new Status(StatusCode.NotFound, "Cookie not found.")) :
            new Cookie { Id = cookie.Id, Message = cookie.Message };
    }
}
