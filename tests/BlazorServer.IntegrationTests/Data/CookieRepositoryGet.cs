
namespace BlazorServer.IntegrationTests.Data;

public class CookieRepositoryGet : BaseCookieRepoTestFixture
{
  [Fact]
  public async Task GetsRandomCookieAsync()
  {
    var repository = GetRepository();
    var cookie = await repository.GetRandomAsync();

    Assert.Contains(cookie?.Message, SeedData.Cookies);
    Assert.True(cookie?.Id > 0);
  }
}
