
namespace BlazorServer.IntegrationTests.Data;

public class CookieRepositoryGet : BaseCookieRepoTestFixture
{
  [Fact]
  public async Task GetsRandomCookie()
  {
    await _dbContext.Cookies.AddRangeAsync(SeedData.Cookies.Select(c => new Cookie { Message = c }));
    await _dbContext.SaveChangesAsync();

    var repository = GetRepository();
    var cookie = await repository.GetRandom();

    Assert.Contains(cookie.Message, SeedData.Cookies);
    Assert.True(cookie.Id > 0);
  }
}
