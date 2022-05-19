﻿
namespace BlazorServer.IntegrationTests.Data;

public class CookieRepositoryGet : BaseCookieRepoTestFixture
{
  private static readonly string[] _cookies =
  {
    "fortune: No such file or directory",
    "A computer scientist is someone who fixes things that aren't broken.",
    "After enough decimal places, nobody gives a damn.",
    "A bad random number generator: 1, 1, 1, 1, 1, 4.33e+67, 1, 1, 1",
    "A computer program does what you tell it to do, not what you want it to do.",
    "Emacs is a nice operating system, but I prefer UNIX. — Tom Christaensen",
    "Any program that runs right is obsolete.",
    "A list is only as strong as its weakest link. — Donald Knuth",
    "Feature: A bug with seniority.",
    "Computers make very fast, very accurate mistakes.",
    "<script>alert('This should not be displayed in a browser alert box.');</script>",
    "フレームワークのベンチマーク"
  };

  [Fact]
  public async Task GetsRandomCookie()
  {
    await _dbContext.Cookies.AddRangeAsync(_cookies.Select(c => new Cookie { Message = c }));
    await _dbContext.SaveChangesAsync();

    var repository = GetRepository();
    var cookie = await repository.GetRandom();

    Assert.Contains(cookie.Message, _cookies);
    Assert.True(cookie.Id > 0);
  }
}
