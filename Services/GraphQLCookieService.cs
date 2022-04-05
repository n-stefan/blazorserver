
namespace Services;

public class GraphQLCookieService : ICookieService
{
    private readonly HttpClient _httpClient;

    public GraphQLCookieService(HttpClient httpClient) =>
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
            var result = await response.Content.ReadFromJsonAsync<CookieResult>();
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
