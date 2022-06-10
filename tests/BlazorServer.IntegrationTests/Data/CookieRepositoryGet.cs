
namespace BlazorServer.IntegrationTests.Data;

public class CookieRepositoryGet : BaseCookieRepoTestFixture
{
  [Fact]
  public async Task GetsRandomCookie()
  {
    var repository = GetRepository();
    var cookie = await repository.GetRandom();

    Assert.Contains(cookie.Message, SeedData.Cookies);
    Assert.True(cookie.Id > 0);
  }
}
