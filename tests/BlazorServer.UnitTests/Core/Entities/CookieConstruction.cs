
namespace BlazorServer.UnitTests.Core.Entities;

public class CookieConstruction
{
  private readonly int _testId = 1;
  private readonly string _testMessage = "fortune: No such file or directory";
  private Cookie? _testCookie;

  private Cookie CreateCookie()
  {
    return new Cookie { Id = _testId, Message = _testMessage };
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

    Assert.Equal(_testMessage, _testCookie.Message);
  }
}
