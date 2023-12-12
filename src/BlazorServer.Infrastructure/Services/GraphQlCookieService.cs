
namespace BlazorServer.Infrastructure.Services;

public class GraphQlCookieService(HttpClient httpClient) : ICookieService
{
  public async Task<CookieDto> GetRandomCookie()
  {
    try
    {
      var payload = new
      {
        query = "{ randomCookie { id message } }"
      };
      var response = await httpClient.PostAsJsonAsync("graphql", payload);
      var result = await response.Content.ReadFromJsonAsync<CookieResultDto>();
      if (result == null)
      {
        return new CookieDto(CookieDto.AnErrorOccurred);
      }
      return result.Errors == null
          ? new CookieDto(result.Data.RandomCookie.Id, result.Data.RandomCookie.Message)
          : new CookieDto(result.Errors[0].Message);
    }
    catch (Exception)
    {
      return new CookieDto(CookieDto.AnErrorOccurred);
    }
  }
}
