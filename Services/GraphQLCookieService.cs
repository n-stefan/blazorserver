
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
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    var content = await response.Content.ReadAsStringAsync();
                    var obj = JsonNode.Parse(content).AsObject();
                    var id = (int)obj["data"]["randomCookie"]["id"];
                    var message = (string)obj["data"]["randomCookie"]["message"];
                    return new CookieDto(id, message);
                default:
                    return new CookieDto(CookieDto.AnErrorOccurred);
            };
        }
        catch (Exception)
        {
            return new CookieDto(CookieDto.AnErrorOccurred);
        }
    }
}
