using Data;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System.Threading.Tasks;

namespace Grpc
{
    public class CookieService : CookieContract.CookieContractBase
    {
        private readonly ICookieRepository _repository;

        public CookieService(ICookieRepository repository) =>
            _repository = repository;

        public override async Task<Cookie> GetRandomCookie(Empty request, ServerCallContext context)
        {
            var cookie = await _repository.GetRandomCookie();
            if (cookie == null)
                throw new RpcException(new Status(StatusCode.NotFound, "Cookie not found."));
            else
                return new Cookie { Id = cookie.Id, Message = cookie.Message };
        }
    }
}
