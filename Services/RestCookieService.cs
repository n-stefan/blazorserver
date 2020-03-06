using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services
{
    public class RestCookieService : ICookieService
    {
        private readonly HttpClient _httpClient;

        public RestCookieService(HttpClient httpClient) =>
            _httpClient = httpClient;

        public async Task<CookieDto> GetRandomCookie()
        {
            var response = await _httpClient.GetAsync("cookie/random");
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    var content = await response.Content.ReadAsStringAsync();
                    var cookie = JsonSerializer.Deserialize<Data.Cookie>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return new CookieDto(cookie.Id, cookie.Message);
                case HttpStatusCode.NotFound:
                default:
                    return null;
            };

            //var cookie = await _httpClient.GetJsonAsync<Cookie>("cookie/random");
            //return (cookie == null) ? null : new CookieDto(cookie.Id, cookie.Message);
        }
    }
}
