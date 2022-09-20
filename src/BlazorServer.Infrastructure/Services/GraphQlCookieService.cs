
namespace BlazorServer.Infrastructure.Services;

public class GraphQlCookieService : ICookieService
{
  private readonly HttpClient _httpClient;

  public GraphQlCookieService(HttpClient httpClient) =>
      _httpClient = httpClient;

  public async Task<CookieDto> GetRandomCookie()
  {
    try
    {
      var payload = new
      {
        query = "{ randomCookie { id message } }"
      };
      var response = await _httpClient.PostAsJsonAsync("graphql", payload);
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
