
namespace BlazorServer.IntegrationTests.Data;

public class CookieRepositoryGet : BaseCookieRepoTestFixture
{
  [Fact]
  public async Task GetsCookieAfterAddingIt()
  {
    var testMessage = "fortune: No such file or directory";
    var cookie = new Cookie { Message = testMessage };

    await _dbContext.Cookies.AddAsync(cookie);
    await _dbContext.SaveChangesAsync();

    var repository = GetRepository();
    var newCookie = await repository.GetRandom();

    Assert.Equal(testMessage, newCookie.Message);
    Assert.True(newCookie.Id > 0);
  }
}
