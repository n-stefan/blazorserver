
namespace BlazorServer.UnitTests.Core.Entities;

public class CookieConstruction
{
  private readonly int _testId = 1;
  private Cookie? _testCookie;

  private Cookie CreateCookie()
  {
    return new Cookie { Id = _testId, Message = SeedData.Cookies[0] };
  }

  [Fact]
  public void InitializesId()
  {
    _testCookie = CreateCookie();

    Assert.Equal(_testId, _testCookie.Id);
  }

  [Fact]
  public void InitializesMessage()
  {
    _testCookie = CreateCookie();

    Assert.Equal(SeedData.Cookies[0], _testCookie.Message);
  }
}
