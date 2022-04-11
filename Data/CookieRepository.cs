
namespace Data;

public class CookieRepository : EfRepository<Cookie, ApplicationDbContext>
{
    public CookieRepository(ApplicationDbContext context) : base(context) { }
}
