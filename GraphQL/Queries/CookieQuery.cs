
namespace GraphQL.Queries;

public class CookieQuery
{
    public async Task<Cookie> GetRandomCookie([Service] IRepository<Cookie> repository)
    {
        var cookie = await repository.GetRandom();
        return cookie ?? throw new GraphQLException("Cookie not found.");
    }
}
