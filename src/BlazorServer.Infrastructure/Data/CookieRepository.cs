
namespace BlazorServer.Infrastructure.Data;

public class CookieRepository : EfRepository<Cookie, AppDbContext>
{
  public CookieRepository(AppDbContext context) : base(context) { }
}
