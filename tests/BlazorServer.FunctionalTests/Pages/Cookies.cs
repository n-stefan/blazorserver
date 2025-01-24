
namespace BlazorServer.FunctionalTests.Pages;

public class Cookies
{
  private static async Task ShowsCookieOnClickAsync()
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

  private static async Task SetupAndRunTestAsync<T, U, V, W>()
    where T : BaseWebAppFactory<V>, new()
    where U : BaseWebAppFactory<W>, new()
    where V : class
    where W : class
  {
    await using var factory = new T();
    factory.CreateClient();

    await using var uiFactory = new U();
    uiFactory.CreateClient();

    await ShowsCookieOnClickAsync();
  }

  [Fact]
  public async Task DirectCookieServiceShowsCookieOnClickAsync()
  {
    await using var uiFactory = new UiWebAppFactory();
    uiFactory.CreateClient();

    await ShowsCookieOnClickAsync();
  }

  [Fact]
  public Task RestCookieServiceShowsCookieOnClickAsync() =>
    SetupAndRunTestAsync<RestWebAppFactory, RestUiWebAppFactory, WebApiRestMarker, WebUiMarker>();

  [Fact]
  public Task ODataCookieServiceShowsCookieOnClickAsync() =>
    SetupAndRunTestAsync<RestWebAppFactory, ODataUiWebAppFactory, WebApiRestMarker, WebUiMarker>();

  [Fact]
  public Task GrpcCookieServiceShowsCookieOnClickAsync() =>
    SetupAndRunTestAsync<GrpcWebAppFactory, GrpcUiWebAppFactory, WebApiGrpcMarker, WebUiMarker>();

  [Fact]
  public Task GrpcJsonCookieServiceShowsCookieOnClickAsync() =>
    SetupAndRunTestAsync<GrpcWebAppFactory, GrpcJsonUiWebAppFactory, WebApiGrpcMarker, WebUiMarker>();

  [Fact]
  public Task GraphQlCookieServiceShowsCookieOnClickAsync() =>
    SetupAndRunTestAsync<GraphQlWebAppFactory, GraphQlUiWebAppFactory, WebApiGraphQlMarker, WebUiMarker>();

  [Fact]
  public Task WcfCookieServiceShowsCookieOnClickAsync() =>
    SetupAndRunTestAsync<WcfWebAppFactory, WcfUiWebAppFactory, WebApiWcfMarker, WebUiMarker>();
}
