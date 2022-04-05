
namespace Services.Models;

public class CookieResult
{
    public CookieContainer Data { get; set; }

    public CookieError[] Errors { get; set; }
}
