
namespace BlazorServer.FunctionalTests.WebApplicationFactories;

public class RestUiWebAppFactory : UiWebAppFactory
{
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    ArgumentNullException.ThrowIfNull(builder);

    base.ConfigureWebHost(builder);

    ConfigureServices<RestCookieService>(builder, new Uri("https://localhost:5003"));
  }
}
