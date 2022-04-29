
namespace BlazorServer.Infrastructure.Services;

public class GrpcCookieService : ICookieService
{
  private readonly IConfiguration _configuration;

  public GrpcCookieService(IConfiguration configuration) =>
      _configuration = configuration;

  public async Task<CookieDto> GetRandomCookie()
  {
    try
    {
      var channel = GrpcChannel.ForAddress(_configuration["GrpcBaseUrl"]);
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
