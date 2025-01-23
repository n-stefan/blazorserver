
namespace BlazorServer.FunctionalTests.WebApplicationFactories;

public class WcfUiWebAppFactory : UiWebAppFactory
{
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    ArgumentNullException.ThrowIfNull(builder);

    base.ConfigureWebHost(builder);

    ConfigureServices<WcfCookieService>(builder);
  }
}
