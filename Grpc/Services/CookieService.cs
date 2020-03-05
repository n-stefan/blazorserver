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
            return (cookie == null) ? null : new Cookie { Id = cookie.Id, Message = cookie.Message };
        }
    }
}
