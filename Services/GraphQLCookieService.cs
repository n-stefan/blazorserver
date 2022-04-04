
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
            string message;
            var payload = new
            {
                query = "{ randomCookie { id message } }"
            };
            var response = await _httpClient.PostAsJsonAsync("graphql", payload);
            var content = await response.Content.ReadAsStringAsync();
            var obj = JsonNode.Parse(content).AsObject();
            if (obj.ContainsKey("errors"))
            {
                message = (string)obj["errors"][0]["message"];
                return new CookieDto(message);
            }
            else
            {
                var id = (int)obj["data"]["randomCookie"]["id"];
                message = (string)obj["data"]["randomCookie"]["message"];
                return new CookieDto(id, message);
            }
        }
        catch (Exception)
        {
            return new CookieDto(CookieDto.AnErrorOccurred);
        }
    }
}
