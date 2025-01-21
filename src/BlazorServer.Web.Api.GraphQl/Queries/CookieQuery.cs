
namespace BlazorServer.Web.Api.GraphQl.Queries;

public class CookieQuery
{
    public async Task<Cookie> GetRandomCookieAsync([Service] IRepository<Cookie> repository)
    {
        ArgumentNullException.ThrowIfNull(repository);

        var cookie = await repository.GetRandomAsync();
        return cookie ?? throw new GraphQLException("Cookie not found.");
    }
}
