
namespace BlazorServer.FunctionalTests.Pages;

public class Cookies : IClassFixture<CustomWebApplicationFactory>
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

  public Cookies(CustomWebApplicationFactory factory)
  {
    factory.CreateDefaultClient();
  }

  [Fact]
  public async Task ShowsCookie_Given_ButtonClick()
  {
    using var playwright = await Playwright.CreateAsync();

    await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
    {
      Headless = false,
      Channel = "msedge"
    });

    var context = await browser.NewContextAsync();

    var page = await context.NewPageAsync();

    await page.GotoAsync("https://localhost:5001", new PageGotoOptions
    {
      WaitUntil = WaitUntilState.NetworkIdle
    });

    await page.Locator("a:has-text(\"Fortune cookies\")").ClickAsync();
    await page.Locator("text=Show me my cookie").ClickAsync();

    var element = page.Locator("div.alert.alert-info");
    Assert.NotNull(element);

    var text = await element.InnerTextAsync();
    Assert.Contains(text, _cookies);
  }
}
