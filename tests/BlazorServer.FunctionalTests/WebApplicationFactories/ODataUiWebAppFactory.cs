
namespace BlazorServer.FunctionalTests.WebApplicationFactories;

public class ODataUiWebAppFactory : UiWebAppFactory
{
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    ArgumentNullException.ThrowIfNull(builder);

    base.ConfigureWebHost(builder);

    ConfigureServices<ODataCookieService>(builder, new Uri("https://localhost:5003"));
  }
}
