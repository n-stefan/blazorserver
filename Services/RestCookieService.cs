using Data;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
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
            var cookie = await _httpClient.GetJsonAsync<Cookie>("cookie/random");
            return (cookie == null) ? null : new CookieDto(cookie.Id, cookie.Message);

            //var response = await _httpClient.GetStringAsync("cookie/random");
            //return JsonSerializer.Deserialize<Cookie>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
