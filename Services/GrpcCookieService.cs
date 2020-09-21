using Google.Protobuf.WellKnownTypes;
using Grpc;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Services
{
    public class GrpcCookieService : ICookieService
    {
        public GrpcCookieService(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public async Task<CookieDto> GetRandomCookie()
        {
            try
            {
                var channel = GrpcChannel.ForAddress(Configuration["GrpcBaseUrl"]);
                var client = new CookieContract.CookieContractClient(channel);
                var cookie = await client.GetRandomCookieAsync(new Empty());
                return new CookieDto(cookie.Id, cookie.Message);
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.NotFound)
            {
                return new CookieDto(CookieDto.CookieNotFound);
            }
            catch (Exception)
            {
                return new CookieDto(CookieDto.AnErrorOccurred);
            }
        }
    }
}
