
namespace BlazorServer.Infrastructure.Services;

public class GrpcCookieService(IConfiguration configuration) : ICookieService
{
  public async Task<CookieDto> GetRandomCookie()
  {
    try
    {
      var url = configuration["GrpcBaseUrl"];
      if (string.IsNullOrWhiteSpace(url))
      {
        throw new Exception("'GrpcBaseUrl' not configured!");
      }

      var channel = GrpcChannel.ForAddress(url);
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
