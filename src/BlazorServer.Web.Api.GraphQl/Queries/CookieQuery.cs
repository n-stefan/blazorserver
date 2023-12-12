
namespace BlazorServer.Web.Api.GraphQl.Queries;

public class CookieQuery
{
    public async Task<Cookie> GetRandomCookie([Service] IRepository<Cookie> repository)
    {
        ArgumentNullException.ThrowIfNull(repository);

        var cookie = await repository.GetRandom();
        return cookie ?? throw new GraphQLException("Cookie not found.");
    }
}
