
namespace BlazorServer.Infrastructure.Data;

public class CookieRepository(AppDbContext context) : EfRepository<Cookie, AppDbContext>(context)
{
}
