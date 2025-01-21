
namespace BlazorServer.UnitTests.Core.Services;

public class DirectCookieServiceGetRandomCookie
{
  private readonly Mock<IRepository<Cookie>> _mockRepository = new();
  private readonly DirectCookieService _directCookieService;

  public DirectCookieServiceGetRandomCookie() =>
    _directCookieService = new DirectCookieService(_mockRepository.Object);

  [Fact]
  public async Task ReturnsErrorDtoGivenDataAccessExceptionAsync()
  {
    const string expectedErrorMessage = CookieDto.AnErrorOccurred;
    _mockRepository.Setup(r => r.GetRandomAsync()).ThrowsAsync(new Exception());

    var result = await _directCookieService.GetRandomCookieAsync();

    _mockRepository.Verify(r => r.GetRandomAsync(), Times.Once);
    Assert.Equal(expectedErrorMessage, result.Error);
  }

  [Fact]
  public async Task ReturnsNotFoundDtoGivenCookieNotFoundAsync()
  {
    const string expectedErrorMessage = CookieDto.CookieNotFound;
    _mockRepository.Setup(r => r.GetRandomAsync()).ReturnsAsync(() => null);

    var result = await _directCookieService.GetRandomCookieAsync();

    _mockRepository.Verify(r => r.GetRandomAsync(), Times.Once);
    Assert.Equal(expectedErrorMessage, result.Error);
  }

  [Fact]
  public async Task ReturnsCookieDtoGivenCookieFoundAsync()
  {
    const string? expectedErrorMessage = null;
    var index = Random.Shared.Next(0, SeedData.Cookies.Length);
    var cookie = new Cookie { Id = index + 1, Message = SeedData.Cookies[index] };
    _mockRepository.Setup(r => r.GetRandomAsync()).ReturnsAsync(cookie);

    var result = await _directCookieService.GetRandomCookieAsync();

    _mockRepository.Verify(r => r.GetRandomAsync(), Times.Once);
    Assert.Equal(expectedErrorMessage, result.Error);
    Assert.Equal(cookie.Id, result.Id);
    Assert.Equal(cookie.Message, result.Message);
  }
}
