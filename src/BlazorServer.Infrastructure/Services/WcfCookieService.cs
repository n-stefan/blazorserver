
using ICookieService = BlazorServer.Core.Interfaces.ICookieService;
using Wcf;

namespace BlazorServer.Infrastructure.Services;

public class WcfCookieService(IConfiguration configuration) : ICookieService
{
  public async Task<CookieDto> GetRandomCookieAsync()
  {
    CookieServiceClient? client = null;
    try
    {
      client = new CookieServiceClient(CookieServiceClient.EndpointConfiguration.WSHttpBinding_ICookieService, $"{configuration["WcfBaseUrl"]}/CookieService/WSHttp");
      await client.OpenAsync();
      var cookie = await client.GetRandomCookieAsync();
      return new CookieDto(cookie.Id, cookie.Message);
    }
    catch (FaultException ex) when (string.Equals(ex.Message, CookieDto.CookieNotFound, StringComparison.Ordinal))
    {
      return new CookieDto(CookieDto.CookieNotFound);
    }
    catch (Exception)
    {
      return new CookieDto(CookieDto.AnErrorOccurred);
    }
    finally
    {
      if (client != null)
      {
        await client.CloseAsync();
      }
    }
  }
}
