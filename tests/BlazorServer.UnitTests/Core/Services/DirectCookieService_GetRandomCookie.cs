
namespace BlazorServer.UnitTests.Core.Services;

public class DirectCookieService_GetRandomCookie
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
    var index = Random.Shared.Next(0, _cookies.Length);
    var cookie = new Cookie { Id = index + 1, Message = _cookies[index] };
    _mockRepository.Setup(r => r.GetRandom()).ReturnsAsync(cookie);

    var result = await _directCookieService.GetRandomCookie();

    _mockRepository.Verify(r => r.GetRandom(), Times.Once);
    Assert.Equal(expectedErrorMessage, result.Error);
    Assert.Equal(cookie.Id, result.Id);
    Assert.Equal(cookie.Message, result.Message);
  }
}
