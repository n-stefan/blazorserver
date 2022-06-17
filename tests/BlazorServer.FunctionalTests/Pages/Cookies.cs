
namespace BlazorServer.FunctionalTests.Pages;

public class Cookies
{
  private static async Task ShowsCookieOnClick()
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
    Assert.Contains(text, SeedData.Cookies);
  }

  [Fact]
  public async Task DirectCookieService_ShowsCookieOnClick()
  {
    using var uiFactory = new UiWebAppFactory();
    uiFactory.CreateClient();

    await ShowsCookieOnClick();
  }

  [Fact]
  public async Task RestCookieService_ShowsCookieOnClick()
  {
    using var restFactory = new RestWebAppFactory();
    restFactory.CreateClient();

    using var restUiFactory = new RestUiWebAppFactory();
    restUiFactory.CreateClient();

    await ShowsCookieOnClick();
  }

  [Fact]
  public async Task ODataCookieService_ShowsCookieOnClick()
  {
    using var restFactory = new RestWebAppFactory();
    restFactory.CreateClient();

    using var oDataUiFactory = new ODataUiWebAppFactory();
    oDataUiFactory.CreateClient();

    await ShowsCookieOnClick();
  }

  [Fact]
  public async Task GrpcCookieService_ShowsCookieOnClick()
  {
    using var grpcFactory = new GrpcWebAppFactory();
    grpcFactory.CreateClient();

    using var grpcUiFactory = new GrpcUiWebAppFactory();
    grpcUiFactory.CreateClient();

    await ShowsCookieOnClick();
  }

  [Fact]
  public async Task GrpcJsonCookieService_ShowsCookieOnClick()
  {
    using var grpcFactory = new GrpcWebAppFactory();
    grpcFactory.CreateClient();

    using var grpcJsonUiFactory = new GrpcJsonUiWebAppFactory();
    grpcJsonUiFactory.CreateClient();

    await ShowsCookieOnClick();
  }

  [Fact]
  public async Task GraphQlCookieService_ShowsCookieOnClick()
  {
    using var graphQlFactory = new GraphQlWebAppFactory();
    graphQlFactory.CreateClient();

    using var graphQlUiFactory = new GraphQlUiWebAppFactory();
    graphQlUiFactory.CreateClient();

    await ShowsCookieOnClick();
  }
}
