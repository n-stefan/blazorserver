
namespace BlazorServer.UnitTests.Core.Services;

public class DirectCookieService_GetRandomCookie
{
  private readonly Mock<IRepository<Cookie>> _mockRepository = new();
  private readonly DirectCookieService _directCookieService;

  public DirectCookieService_GetRandomCookie() =>
    _directCookieService = new DirectCookieService(_mockRepository.Object);

  [Fact]
  public async Task ReturnsErrorDto_Given_DataAccessException()
  {
    var expectedErrorMessage = CookieDto.AnErrorOccurred;
    _mockRepository.Setup(r => r.GetRandom()).ThrowsAsync(new Exception());

    var result = await _directCookieService.GetRandomCookie();

    _mockRepository.Verify(r => r.GetRandom(), Times.Once);
    Assert.Equal(expectedErrorMessage, result.Error);
  }

  [Fact]
  public async Task ReturnsNotFoundDto_Given_CookieNotFound()
  {
    var expectedErrorMessage = CookieDto.CookieNotFound;
    Cookie? cookie = null;
    _mockRepository.Setup(r => r.GetRandom()).ReturnsAsync(cookie);

    var result = await _directCookieService.GetRandomCookie();

    _mockRepository.Verify(r => r.GetRandom(), Times.Once);
    Assert.Equal(expectedErrorMessage, result.Error);
  }

  [Fact]
  public async Task ReturnsCookieDto_Given_CookieFound()
  {
    string? expectedErrorMessage = null;
    var index = Random.Shared.Next(0, SeedData.Cookies.Length);
    var cookie = new Cookie { Id = index + 1, Message = SeedData.Cookies[index] };
    _mockRepository.Setup(r => r.GetRandom()).ReturnsAsync(cookie);

    var result = await _directCookieService.GetRandomCookie();

    _mockRepository.Verify(r => r.GetRandom(), Times.Once);
    Assert.Equal(expectedErrorMessage, result.Error);
    Assert.Equal(cookie.Id, result.Id);
    Assert.Equal(cookie.Message, result.Message);
  }
}
